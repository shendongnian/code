        DataTable dt = new DataTable();
        DataColumn dcol = new DataColumn("ID", typeof(System.Int32));
        dcol.AutoIncrement = true;
        dt.Columns.Add(dcol);
        int days = 0;
        string selected_month = "JAN";
        if (selected_month == "JAN" || selected_month == "MAR")
        { days = 31; }
        else if(selected_month == "APR")
        { days = 30; }
        for (int z = 1; z < days; z++)
        {
            dcol = new DataColumn(z.ToString(), typeof(System.String));
            dt.Columns.Add(dcol);
        }
