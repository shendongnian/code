    public interface IAbcAccessor
    {
      int abc {get; set;}
    }
    
    internal abstract class A
      : IAbcAccessor
    {
        private int _abc;
        public int abc
        {
           get{return _int;}
           set{_abc=value;}
        }
    
        int IAbcAccessor.abc
        {
           get{return abc;}
           set{abc = value;}
        }
    }
