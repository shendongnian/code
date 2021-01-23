       var sameRecords = from table1 in dtFirst.AsEnumerable() join table2 in  secondDt.AsEnumerable() on table1.Field<string>("abc") equals table2.Field<string>("def") where table1.Field<string>("abc") == table2.Field<string>("def") select table1;
            if (sameRecords .Count() > 0)
            {
               //Copy selected recors to the Data Table object
                DataTable dt =sameRecords .CopyToDataTable();
            }
