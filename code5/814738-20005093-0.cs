    bool found = false;
    string client;
    string number = txtNumber.Text;
        foreach (Account ac in tabAccounts)
        {
            if (txtNumber.Text == ac.Number)
            {
                found = true;
                client = ac.Client;
                break;
            }
        }
    if (found)
    {
      this.Height = 328;
      lblWelcome.Text = "Welcome: " + client;
    }
    else
    {
      MessageBox.Show("Account Number not found");
    }
