    //set variables in another form. not sure if these are working
    Variables1.selectedAccount = matches.Name;
    //is this calling the CheckBalance of the instance?
    Variables1.selectedCheckBalance = matches.CheckBalance;
    //same thing?
    Variables1.selectedSaveBalance = matches.SaveBalance;
    
    //switch to form
    AccountMenu acctMenu = new AccountMenu();
    acctMenu..OnPassDataToAccount += childwindow_OnPassDataToAccount;
    this.Hide();
    acctMenu.Show();
    }
    void childwindow_OnPassDataToAccount(string result)
    {
      if (result == "result")
      {
      // Processing required on your parent window can be caried out here
      //Variables1 can be processed directly here.
      }
    }
