     for (int i = 0; i < IncTbl.Rows.Count; i++)
            {
                if (!IncTbl.CurrentRow.IsNewRow)
                  yearSalary += (decimal)IncTbl[4,i].Value;
            }
