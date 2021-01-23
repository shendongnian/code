     public ICollection Bars
      {
        get { return this.bars; }
        set 
        {
          if (value != null && value.Count > 6)
          {
            throw Exception("A Foo can only have up to 6 Bars."); // Which exception to throw?
          }
        }
      }
