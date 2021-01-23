    private void BtnExit_Click(object sender, EventArgs e)
    {
      Thread1.IsBackground = false;
      Thread2.IsBackground = false;
      Application.exit();
    }
