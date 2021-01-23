    bool CheckExisting()
    {
            Account loginAcc = new Account();
    
            string path = Application.StartupPath.ToString() + "\\Customers";
            int fCount = Directory.GetFiles(path, "*.xml", SearchOption.AllDirectories).Length;
    
            for(int i = 0;i<fCount;i++)
            {
                String[] filePaths = Directory.GetFiles(Application.StartupPath + "\\Customers\\");
                XmlDocument xmlFile =new XmlDocument();
                xmlFile.Load(filePaths[i]);
    
                foreach(XmlNode node in xmlFile.SelectNodes("//Account"))
                {
                    string firstName = node.SelectSingleNode("FirstName").InnerText;
                    string lastName = node.SelectSingleNode("LastName").InnerText;
                    string address1 = node.SelectSingleNode("Address1").InnerText;
                    string address2 = node.SelectSingleNode("Address2").InnerText;
                    string postCode = node.SelectSingleNode("Postcode").InnerText;
                    string telePhone = node.SelectSingleNode("Telephone").InnerText;
                    string mobile = node.SelectSingleNode("Mobile").InnerText;
    
                    Account newAcc = new Account();
    
                    newAcc.firstName = firstName;
                    newAcc.lastName = lastName;
                    newAcc.address1 = address1;
                    newAcc.address2 = address2;
                    newAcc.postCode = postCode;
                    newAcc.telephone = telePhone;
                    newAcc.mobile = mobile;
    
                    loginAcc = newAcc;
                }
    
    
                if(txtFirstName.Text == loginAcc.firstName && txtLastName.Text == loginAcc.lastName)
                {
                    return true;
                }
                else
                {
                    return  false;
                } 
            return false;       
            }
    
          return false;
        }
