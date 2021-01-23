    class Parent
    {
        protected void Add(DataTable dt) { ... }
    }
    
    class Child1:Parent
    {
        public void Add(MyTable1 anything)
        {
            // pseudo code
            DataTable dt = new DataTable();
            foreach(row r in anything)
            {
                dt.AddRow(r);
            }
    
            this.Add(dt);
        }
    }
    
    class Child2:Parent
    {
        public void Add(MyTable2 anything)
        {
            ...
        }
    }
