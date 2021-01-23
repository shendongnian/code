        if (!email_Match.Success)
        {
            MessageBox.Show(this,
                "Please Enter A Valid Email Adress !",
                "Error While Connecting !",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button3);
        }
        else if (!password_Match.Success)
        {
            MessageBox.Show(this,
                "Please Enter A Valid Password !",
                "Error While Connecting !",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button3);
        }
     
        else
        {
           File.WriteAllText(@"D:\Password.txt", password);
           File.WriteAllText(@"C:\Email.txt", eMail);
        }
