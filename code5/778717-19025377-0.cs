    private void Clicked(object sender, EventArgs e)
    {
      Application.Exit();
    }
    private void FormClosing(object sender, CancelEventArgs e)
    {
      Cleanup();
    }
    private void Cleanup()
    {
      // do cleanup here
    }
