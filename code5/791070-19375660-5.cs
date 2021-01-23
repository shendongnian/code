    Public ICollection get_Bars()
    {    
        return this.bars;    
    }
    Public ICollection set_Bars(ICollection value)
    {    
      if (value != null && value.Count > 6)
      {
        throw new Exception("A Foo can only have up to 6 Bars."); // Which exception to throw?
      }   
    }
