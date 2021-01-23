    public void SubmitClicked(String answersJsonStr)
    {
        Debug.WriteLine("SubmitClicked() " + answersJsonStr);
        XNode node = JsonConvert.DeserializeXNode(answersJsonStr, "Root");
        var answersXml = node.ToString();
        //This gives: "<Root>\r\n  <question1>answer 1</question1>\r\n</Root>"
        String fullUrl = "http://localhost:61728/SubmitSurveyAnswers";
        using (WebClient client = new WebClient())
        {
          client.Headers.Add("Content-Type","application/x-www-form-urlencoded");
          byte[] bret = client.UploadData(fullUrl, "POST", System.Text.Encoding.ASCII.GetBytes(answersXml));
          Debug.WriteLine(System.Text.Encoding.ASCII.GetString(bret));
        }
    }
