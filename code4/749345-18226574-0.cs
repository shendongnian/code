        class mymodel
        {
            private string _ampm;
            public string Name{ get; set; }
            public string AMPM
            {
                get { return _ampm; }
                set 
                {
                    _ampm = value;
                    AMPM_Sort = AppropriateSort();
                }
            }
    
            public int AMPM_Sort { get; private set; }
    
            private int AppropriateSort()
            {
                if (AMPM == "AM")  return 1;
                if (AMPM == "PM")  return 2;
                if (AMPM == "MIX") return 3;
                return AMPM == "--" ? 4 : 9;
            }
        }
    }
    
    List<mymodel> mylist;
    var sorted = mylist.OrderBy(x => x.AMPM_Sort);
