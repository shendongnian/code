        string MyCompany
        {
          get
          {
            string myString = Properties.Resource.ResourceManager.GetString ("MyCompany_" + theCompanyPostfix);
            if (myString == null)
            {
                myString = Properties.Resource.ResourceManager.GetString ("MyCompany");
            }
            return myString;
          }
        }
