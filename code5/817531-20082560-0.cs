    private void StartUp()
    {
     try
     {
        MessageBox.Show(p1.Count.ToString());
        Piccy temp = p1.Get(1);
        this.Dispatcher.Invoke((Action)(()=>imgMain.Source = temp.Img);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message+"\n\n"+ex.Source+"\n\n"+ex.StackTrace, "Error");
      }
   }
