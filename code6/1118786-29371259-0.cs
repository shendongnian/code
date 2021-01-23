                var type = MyExtensions.GetDataType(column as Enum);
                                                                       
            DataTable dtAscen; //=logic to read table;
            List<object> listBeforeSort = (from x in dtAscen.AsEnumerable()
                                select (object)Convert.ChangeType(x.Field<string>(column.ToString()), type)).ToList();
            var temp = listBeforeSort.OrderBy(s => s);
            if(!listBeforeSort.SequenceEqual(temp))            
                Utilities.log("Issue with ascending sort on column " + column.ToString(), LogType.ErrorEntry);
