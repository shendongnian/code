        class CSVRow{
             Dictionary<string, string> Values;
              public CSVRow(string csvFields, string csvValues)
                {
                    // iterate properly and fill the fields that contains values.
                }
             string ToInsert(){
                  string csvFields="Insert into csv123 (";
                   string csvValues="VAlues(";
                  foreach(KeyValuePair<string, string> entry in Values)
                   {
                        
                         if(string.isEmpty(entry.Value)==false){ //double check? probably not need it.
                             // add the field to the insert and the value to the values.
                             }
                  }
                  
                return csvFields + ") " + csvValues + ")";
               }
        }
