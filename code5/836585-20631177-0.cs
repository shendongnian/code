    var data = from x in table.AsEnumerable()
                        where x.Field<string>("UserId").ToUpper().ToString().Equals(compare.ToUpper().ToString())
                        select x;
            DataTable boundTable = data.AsDataView().ToTable();
            return boundTable;
