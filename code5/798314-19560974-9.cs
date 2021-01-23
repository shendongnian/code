    public class TableRow
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool add { get; set; }
        public bool edit { get; set; }
        public bool view { get; set; }
        public bool authorize { get; set; }
        public TableRow(object[] itemArray)
        {
            id = Int32.Parse(itemArray[0].ToString());
            name = itemArray[1].ToString();
            add = bool.Parse(itemArray[2].ToString());
            edit = bool.Parse(itemArray[3].ToString());
            view = bool.Parse(itemArray[4].ToString());
            authorize = bool.Parse(itemArray[5].ToString());
        }
    }
