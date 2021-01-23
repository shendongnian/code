    public abstract class ParameterDataClass
    {
      public abstract bool CompareTo(StreamClass Stream);
    } // class ParameterDataClass
    public /* concrete */ class DataComparerClass
    {
      internal /* nonvirtual */ void InternalComparison(string Data) { ... }
      public /* nonvirtual */ bool CompareThis(ParameterDataClass Data)
      {
        bool Result = false;
        
        if (Data != null)
        {
           Result = Data.CompareTo(this);
        }
      } // bool CompareThis(...)
    } // class StreamClass
    public /* concrete */ class CustomerClass: StreamDataClass
    {
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public DateTime BirthDate { get; set; }
      public override bool CompareTo(StreamClass Stream)
      {
        bool Result = false;
        
        if (Stream!= null)
        {
          string Temp = "{" +
            FirstName.ToString() + "," +
            LastName.ToString() + "," +
            BirthDate.ToString() + "}"
          Result = Data.CompareTo(Temp);
        }
      } // bool CompareTo(...)
      
      return Result;
    } // class CustomerClass
    public /* concrete */ class AreaClass: StreamDataClass
    {
      public int Top { get; set; }
      public int Left { get; set; }
      public int Width { get; set; }
      public int Height { get; set; }
      public override bool CompareTo(StreamClass Stream)
      {
        bool Result = false;
        
        if (Stream!= null)
        {
          string Temp = "{" +
            Top.ToString() + "," +
            Left.ToString() + "," +
            Width.ToString() + "," +
            Height.ToString() + "}"
          Result = Data.CompareTo(Temp);
        }
      } // bool CompareTo(...)
      
      return Result;
    } // class AreaClass
    public /* concrete */ class IntegerClass: StreamDataClass
    {
      public int RealVaLue { get; set; }
      public override bool CompareTo(StreamClass Stream)
      {
        bool Result = false;
        
        if (Stream!= null)
        {
          Result = Data.CompareTo(RealValue.ToString());
        }
      } // bool CompareTo(...)
      
      return Result;
    } // class IntegerClass
