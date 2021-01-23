    class Something
    {
        protected void DoSomethingSpecial<TYPE>(TYPE item)
        {
        }
    
        public void DoSomethingy<TYPE>(IEnumerable<TYPE> items)
        {
            foreach(TYPE item in items)
            {
              // do whatever you have to do for every type
        
              // do whatever you have to do in special
              this.onDoSomethingSpecial(item)
            }
        }
    }
