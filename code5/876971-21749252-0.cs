    void Closeclick(.......)
    {
       foreach(UserControl uc in childControls)
       {
          uc.Close();
       }
    }
    
    void ActivateClick(.......)
    {
        HomeForm home = new HomeForm();
        childControls.Add(home);
        home.Show();    
    }
