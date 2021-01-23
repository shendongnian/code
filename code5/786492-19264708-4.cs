        TotalNumberSolStepAdded++;
        Number++;
        string str = (string)ViewState["btnId"];
        if (str != null)
        {
            string resultString = Regex.Match(str, @"\d+").Value;
            a = int.Parse(resultString);
            table = (DataTable)ViewState["t"];
            if (table == null)
            {
                DataTable table1 = new DataTable();
                table1.Columns.Add("count", typeof(int));
                dr = table1.NewRow();
                table1.Rows.Add(dr);
                table1.Rows[a - 1]["count"] = Number;
                table1.AcceptChanges();
                ViewState["t"] = table1;
            }
            else
            {
                if (a != table.Rows.Count)
                {
                    dr = table.NewRow();
                    table.Rows.Add(dr);
                }
                table.Rows[a - 1]["count"] = Number;
                table.AcceptChanges();
                ViewState["t"] = table;
            }
        }
        AddMoreStepControls(TotalNumberSolStepAdded, Number);
    }
