    foreach(var item in MyList)
    {
         ArrList.Add(new MyDB_Tables
         {
             ID = item.ID;
             GroupNumber = item.GroupNumber;
             ModelName = item.ModelName;
             Picture = item.Picture;
         });
    }
