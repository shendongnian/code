    int iCurrentCount = 0;
    int iTotalNumOfRec = 0;
    
    
    iTotalNumOfRec = getNumOfRec("SELECT COUNT(*) FROM myTable)
    
    dt = fillMyDataTable(sql);           
    int i = 0;
        
          while (i < iTotlNumOfRec)
          {
               DataRowChangeEventArgs args = new DataRowChangeEventArgs(dt.Rows[i], DataRowAction.Add);
               dt_RowChanged(this, args);
               ++i;
          }
        
         void dt_RowChanged(object sender, DataRowChangeEventArgs e)
         {
              if (e.Action == DataRowAction.Add)
              {               
                   Console.WriteLine("Current rec. no.: " + iCurrentCount.ToString());
                   iCurrentCount++;
               }
          }
