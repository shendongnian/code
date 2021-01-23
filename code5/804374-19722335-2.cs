    PayDBDataContext db = new PayDBDataContext(ConnectionStrings.ConnectionString);
    UserInfo ui = db.UserInfos.SingleOrDefault(x => x.ID == userID);
    if(ui.isactive==false)
        return;
    int p= (int)(newSell.Price*0.99);
    //---and maybe some other more time consuming calculations
    ui.credit+=p;       
    
    UserInfo uiCon =db.UserInfos.SingleOrDefault(x=>x.ID==userID);
    if(uiCon.dateModified != ui.dateModified)
    {
        //generate validation error and ask the user to reperform calculations
         return;
    }
    db.SubmitChanges();
    db.Connection.Close();
