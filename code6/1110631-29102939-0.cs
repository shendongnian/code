    example.Tables[0].Columns.Add("...", typeof(string));
    foreach(var row in example.Tables[0].Rows)
    {
         if(row["AverageCost"] != DBNull.Value)
              row["AverageCostText"] = row["AverageCost"].ToString();
          else { row["AverageCostText"] = String.Empty; }
    }
