    using (var dt = new DataTable())
    {
         var keys = responses.SelectMany(x => ((IDictionary<string, object>)x).Keys).Distinct();
         var columns = keys.Select(x => new DataColumn(x)).ToArray();
         dt.Columns.AddRange(columns);
         foreach(IDictionary<string, object> response in responses)
         {
             var row = dt.NewRow();
             foreach (var kvp in response)
             {
                 row[kvp.Key] = kvp.Value;
             }
             dt.Rows.Add(row);
         }
         // write to CSV
    }
