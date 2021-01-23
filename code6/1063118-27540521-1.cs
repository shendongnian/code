    // previous code
    while (Dr.Read())
    {
        if ((UserName == Dr["UserName"].ToString()) && (Password ==     Dr["Password"].ToString()))
        {
            boolReturnValue = true;
            break;
        }
    }
    Dr.Close();
    return boolReturnValue;
