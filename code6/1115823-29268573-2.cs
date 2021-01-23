    public IEnumerable<DataRow> test(DataTable myTable)
        {
            var results = myTable.AsEnumerable()
                .GroupBy(datarow => datarow .ItemArray[1]).Select(y=> y.First()) ;
            return results;
        }
