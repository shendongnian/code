                DataTable tbl = new DataTable();
                tbl.Columns.Add("Col1");
                tbl.Columns.Add("Col2");
    
                string numbers ="One,Two;Three,Four;Five,Six";
    
                string[] array = numbers.Split(';');
    
                foreach(string s in array)
                {
                    DataRow row = tbl.NewRow();
                    string[] numb = s.Split(',');
                    row["Col1"] = numb[0];
                    row["Col2"] = numb[1];
    
                    tbl.Rows.Add(row);
                }
