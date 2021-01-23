        public string getcolumns(DataTable dt,string[] array)
        {
            string columns = "";
            foreach (DataColumn column in dt.Columns)
            {
				if(array.Contains(column.ColumnName))
				{
                columns += column.ColumnName + ",";
				}
		   }
		   return columns;
		}
