    private void Form1_Load(object sender, EventArgs e)
    {
      if (Settings.Instance.HideAtStartup)
      {
        BeginInvoke(new MethodInvoker(delegate
        {
            Hide();
        }));
    }
    }
