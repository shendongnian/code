    private void btnOpenScriptFile_Click(object sender, EventArgs e)
    {
       try
       {
          if (objDialogResult.Equals(DialogResult.OK))
          {
             _ProgressBar.Style = ProgressBarStyle.Marquee;
             _ProgressBar.BeginInvoke(new MethodInvoker(() => _ProgressBar.Visible = true));
             for (int i = 0; i < 100; i++)
             {
             Thread.Sleep(10);
             _ProgressBar.BeginInvoke(new Action(() => _ProgressBar.Value = i));
             //Process my file here
             }
          }
       }
       Catch
       {
       }
    }
