    using (MyEntities me=new MyEntities())
    {
         if( (from t in me.MyTables where mt.Id == 132 select t).Any())
         {    
             MyTable mt= (from t in me.MyTables where mt.Id == 132 select t).Single();
             mt.MyColumn= "Value";
             me.SaveChanges();
         }
    }
