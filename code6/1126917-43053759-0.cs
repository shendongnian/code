            string PasswordGmail = "XXXXXX";
            foreach (char item in PasswordGmail.ToCharArray())
            {
                psw.AppendChar(item);
            }
            client.Credentials = new System.Net.NetworkCredential("XXXX@xxx.com", psw); 
