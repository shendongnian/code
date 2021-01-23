    using (MyEntities me=new MyEntities())
    {
         List<MyTable> listOfMyTable= (from t in me.MyTables where mt.Id == 132 select t).ToList();
         if(listOfMyTable.Count==1)
         {    
             MyTable mt=listOfMyTable[0]//listOfMyTable.Single();
             mt.MyColumn= "Value";
             me.SaveChanges();
         }
    }
