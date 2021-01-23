            //Datasource.
            list<User> DataBoundSource = new list<User>();
            DataGrid.DataSource = DataBoundSource;
            DataGrid.DatBind();
            //Assign to Session where you are binding this
            //every time
            Session["SameID"] = lsDataBoundSOurce;
            
            //your code.
            ...
            ...
            ...
            //covert that session to Datasource you want to save.
            list<User> saveData = (list<User>) Session["SameID"];
