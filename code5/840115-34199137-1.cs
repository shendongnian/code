    void btnDo_Click(object sender, EventArgs e)
    {
      var request = WebRequest.Create(tbxUrl.Text);
      request.BeginGetResponse(FirstCallback, request);
      
      var newUrl = new StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd();
      
      request = WebRequest.Create(newUrl);
      var data = new StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd();
      
      lblData.Text = data;
    }
    
    void FirstCallback(IAsyncResult result)
    {
      var response = ((WebRequest)result.AsyncState).EndGetResponse(result);
      
      var newUrl = new StreamReader(response.GetResponseStream()).ReadToEnd();
      
      var request = WebRequest.Create(newUrl);
      request.BeginGetResponse(SecondCallback, request);
    }
    
    void SecondCallback(IAsyncResult result)
    {
      var response = ((WebRequest)result.AsyncState).EndGetResponse(result);
      
      var data = new StreamReader(response.GetResponseStream()).ReadToEnd();
      
      BeginInvoke((Action<object>)UpdateUI, data);
    }
    
    void UpdateUI(object data)
    {
      lblData.Text = (string)data;
    }
