        string[] strValues;
        for (int i = 0; i < dtTable.Rows.Count; i++)
        {
            strValues= dtTable.Rows[i]["Column_Name"].ToString().Split(',');
            if (strValues.Length > 1)
            {
                dtTable.Rows[i]["Column_Name"] = strValues[0];
                for (int j = 1; j < strValues.Length; j++)
			    {
                    var TargetRow = dtTable.NewRow();
                    var OriginalRow = dtTable.Rows[i];
                    TargetRow.ItemArray = OriginalRow.ItemArray.Clone() as object[];
                    TargetRow["Column_Name"] = strValues[j];
                    dtTable.Rows.Add(TargetRow);
			    }
            }
        }
