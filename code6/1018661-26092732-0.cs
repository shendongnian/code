     public delegate void PassDataToAccounts(string result);
     public event PassDataToAccounts OnPassDataToAccount;
    protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
    {
      if (OnPassDataToAccount != null)
          OnPassDataToAccount("result");
      base.OnClosing(e);
    }
