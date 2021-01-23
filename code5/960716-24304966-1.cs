    class Table : IEnumerable<Table>
    {
        public Table this[string tableName]
        {
            get
            {
                Table table;
                if(mi.tables.TryGetValue(tableName, out table))
                {
                    return table;
                }
                else
                {
                    return null;
                }
            }
        }
    }
