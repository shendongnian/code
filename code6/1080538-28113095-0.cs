    delegate void UpdateDelegate(string text);
    private void UpdateInformation(string text)
    {
       if(this.InvokeRequired)
       {
          UpdateDelegate ud = new UpdateDelegate(UpdateInformation);
          this.BeginInvoke(ud, new object[] { text } );
       }
       else 
       {
          this.myTextBox.Text = text;
       }
    }
