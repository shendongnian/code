    class MyClass
    {
        private DataTable dt = new DataTable();
        public MyClass()
        {
           //initialize your table
        }
        //this is an indexer property which make you able to index any object of this class
        public object this[int row,int column] 
        {
            get
            {
                return dt.Rows[row][column];
            }
        }
        
        /*this won't work (you won't need it anyway)
         * public object this[int row][int col]*/
        //in case you need to access by the column name
        public object this[int row,string columnName]
        {
            get 
            {
                return dt.Rows[row][columnName];
            }
        }
    
    
        
    }
