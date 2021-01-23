    DataSet DS;                             // if you don't already have one..
                                      
    DS = new DataSet();                     // ..create it
    DataTable DT = DS.Tables[0].Clone();    // the temp table has the sdame structure
    DT.TableName = "temp";                  // is called by a name
    DS.Tables.Add(DT);                      // and (optionally) added to the DataSet.
