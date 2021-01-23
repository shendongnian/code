    string[] MyArray = new string[3];
            MyArray[0] = "Tom";
            MyArray[1] = "Canada";
            MyArray[2] = "+42-54948354-9";
            DataTable table = new DataTable();
            table.Columns.Add("Name");
            table.Columns.Add("Address");
            table.Columns.Add("CellNo");
            for (int j = 0; j < 2; j++)
            {
                DataRow drow;
                drow = table.NewRow();
                drow.ItemArray = MyArray;
                table.Rows.InsertAt(drow, j);
            }
