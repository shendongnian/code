     public  DataTable SearchRecords(string Col1, DataTable RecordDT_, int KeyWORD)
        {
            TempTable = RecordDT_;
            DataView DV = new DataView(TempTable);
            DV.RowFilter = string.Format(string.Format("Convert({0},'System.String')",Col1) + " LIKE '{0}'", KeyWORD);
            return DV.ToTable();
        }
