            myReader = cmdDataBase.ExecuteReader();
            if(myReader.Read())
            {
                string sType = myReader["name_of_field"].ToString();
                switch (sType)
                {
                    case "Low": txtDesc.MaxLength = 5; break;
                    case "Medium": txtDesc.MaxLength = 10; break;
                   case "High": txtDesc.MaxLength = 1; break;
                }
            }
