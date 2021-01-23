    void sendDocument()
        {
            string url = "www.mysite.com/page.php";
            StringBuilder postData = new StringBuilder();
            postData.Append(String.Format("{0}={1}&", HttpUtility.HtmlEncode("prop"), HttpUtility.HtmlEncode("value")));
            postData.Append(String.Format("{0}={1}", HttpUtility.HtmlEncode("prop2"), HttpUtility.HtmlEncode("value2")));
            StringContent myStringContent = new StringContent(postData.ToString(), Encoding.UTF8, "application/x-www-form-urlencoded");
            HttpClient client = new HttpClient();
            HttpResponseMessage message = client.PostAsync(url, myStringContent).GetAwaiter().GetResult();
            string responseContent = message.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }
