            dg_Transactions.Columns.Add("1", "Date");
            dg_Transactions.Columns.Add("2", "Amount");
            dg_Transactions.Columns.Add("3", "Description");
            foreach (var row in data.Transactions)
            {
                var n = dg_Transactions.Rows.Add();
                var i = 0;
                dg_Transactions.Rows[n].Cells[i++].Value = row.Date;;
                dg_Transactions.Rows[n].Cells[i++].Value = row.Amount;
                dg_Transactions.Rows[n].Cells[i++].Value = row.Description;
            }
