     public System.Data.DataSet spe_ISUpgradePossible(dbObject  currentDBObj, out int result)
     {
         ......
         // Assign the output parameter to the output variable passed in the method call
         result = Convert.ToInt32(command.Parameters["@Result"].Value.ToString());
         return dataSet;
     }
