    public void MyMessageBox()
    {
      var thread = new Thread(() =>
      {
          MessageBox.Show(...);
      });
      thread.Start();
    }
