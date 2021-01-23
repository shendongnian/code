    foreach (User usr in userList)
    {
        if (uname.Text == usr.uname)
        {
            uname.Email= newEmail; // where newEmail is local variable with new value for password
            uname.Phone = newPhone;
            // ... changing other properties, just don't change Password property
        }
     }
