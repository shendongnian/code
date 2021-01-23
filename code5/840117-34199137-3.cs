    async void btnDo_Click(object sender, EventArgs e)
    {
      var request = WebRequest.Create(tbxUrl.Text);
      var newUrl = new StreamReader((await request.GetResponseAsync()).GetResponseStream())
                   .ReadToEnd();
      
      request = WebRequest.Create(newUrl);
      var data = new StreamReader((await request.GetResponse()).GetResponseStream())
                 .ReadToEnd();
      
      lblData.Text = data;
    }
