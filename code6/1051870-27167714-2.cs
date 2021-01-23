    ArrayList<DataRow> summarizedRecords = table.Rows.GroupBy(row => row["name"]) // this line groups the records by "name"
                  .Select(group => 
                          {
                            int sum = group.Sum(item => item["n"]);  // this line sums the "n"'s of the group
                            DataRow newRow = new DataRow();  // create a new DataRow object
                            newRow["name"] = group.Key;      // set the "name" (key of the group)
                            newRow["n"] = sum;               // set the "n" to sum
                            return newRow;                   // return that new DataRow
                          })
                  .ToList();     // make the resulting enumerable a list
