    bool userFound = false;
    foreach (DataRow row in usersDataSet.Users)
    {
        if (row["Ime_Priimek"].ToString() == userName1)
        {
            if (row["Password"].ToString() == userPassword1)
            {
                userFound = true;
                Pass myForm1 = new Pass();
                Matjaz myForm2 = new Matjaz();
                myForm2.Show();
                myForm1.Hide();
                break;
            }
        }
    }
    if (!userFound)
    {
        MessageBox.Show("You have entered a wrong user name or the password!");
    }
