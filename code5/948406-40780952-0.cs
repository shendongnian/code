    Simply you can do something like this
    
    In your C# class introduce new property named called Empty.
    
    public class YourClass
    {
       
        public bool Empty
        {
            get 
            { 
                return ( ColumnID== 0 )
            }
        }
    }
    
    Then in your Razor view you can use this Empty property for check weather model has values or not
     
    @if (Model.Empty)
    {
       @*what ever you want*@
    }
    else
    {
       @*what ever you want*@
    }
