    private void SetCbSqlTabel_B1Text(string text)
    {
      if(this.InvokeRequired)
      {
        this.Invoke(new Action(() => SetCbSqlTabel_B1Text(text)));
      }
      else
      {
        cbSqlTabel_B1.Text = text;
      }
    }
