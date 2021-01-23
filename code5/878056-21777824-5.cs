    string[] MyArray = new string[3];
            MyArray[0] = "Tom";
            MyArray[1] = "Canada";
            MyArray[2] = "+42-54948354-9";
            DataTable table = new DataTable();
            //table.Columns.Add("Name");
            //table.Columns.Add("Address");
            //table.Columns.Add("CellNo");
            DataRow drow;
            drow = table.NewRow();
            for (int j = 0; j < 2; j++)
            {
                table.Columns.Add(j.ToString());
                string s = string.Join(" ", MyArray);
                drow[j.ToString()] = s;
            }
            table.Rows.Add(drow);
