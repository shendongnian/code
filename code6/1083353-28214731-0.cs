    private async void button1_Click(object sender, EventArgs e)
    {
         button1.Enabled = false;
         try
         {
              //Code will wait here for your method to return without blocking UI Exceptions or Result will be automatically Scheduled to UI thread
              string result = await DoStuffAsync("myParameter");
         }
         catch
         {
              MessageBox.Show("Ups an error");
         }
         finally
         {
             button1.Enabled = true;
         }
    
    }
    
    public Task<string> DoStuffAsync(string s)
    {
       return Task.Factory.StartNew(DoStuff, s);
    }
    
    public string DoStuff(string s)
    {
          //do your normal code;
          return result
    }
