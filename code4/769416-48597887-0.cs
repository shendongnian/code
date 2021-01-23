    foreach (var setting in FullList)
      {
        if(cleanList.Exists(x => x.ProcedureName == setting.ProcedureName)) 
           setting.IsActive = true; // do you business logic here 
         else
           setting.IsActive = false;
        updateList.Add(setting);
      }
