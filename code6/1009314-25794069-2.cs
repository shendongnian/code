    private string GetCbSqlTabel_B1Text()
    {
      if(this.InvokeRequired)
      {
        return (string)this.Invoke(new Func<string>(() => GetCbSqlTabel_B1Text()));
      }
      else
      {
        return cbSqlTabel_B1.Text;
      }
    }
