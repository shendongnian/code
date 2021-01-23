     public System.Data.DataSet spe_ISUpgradePossible(dbObject  currentDBObj, out int result)
     {
         ......
         result = Convert.ToInt32(command.Parameters["@Result"].Value.ToString());
         return dataSet;
     }
