    try
        {
           var Query= db.listdata.FirstOrDefault(x => x.ID == ID);
           Query.TimeStart = "NewValue";
           Query.TimeEnd  = "NewValue";
           Query.AppName = "",
           db.SubmitChanges();
        }
        catch(Exception ex)
        {
            string str = ex.Message.ToString();
        }
