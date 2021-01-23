    class PageIndex{
        private int index;
        public int Index{get{return index;} 
            set{
                index = value;
                OnPageIndexChange();
            }
        }
    
        public Action OnPageIndexChange{get;set;} // change this to event-based
    }
