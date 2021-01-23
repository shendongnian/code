    db.Service Login = new db.Service();
    DataSet ds = Login.login(lUser.Text, lPass.Text);
    bool isAdmin = false;
   
    //Check if there is a record for the username and password
    if(ds.Tables[0].Rows.Count == 1)
    {
        //now check if user is an admin or not
        isAdmin = Convert.ToBoolean(ds.Tables[0].Rows[0]["admin"]);
        if(isAdmin)
        {
            //User is an admin
        }
    }else{
       //User does not exist in the database
    }
    
