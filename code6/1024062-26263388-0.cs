    class Mime
    {
    }
    class MimeTable : List<Mime>
    {
    }
    class Widget
    {
        public void Add<T>( T entity ) where T:class
        {
            Console.WriteLine("Add/1 overload #1" ) ;
        }
        public void Add<T>( IEnumerable<T> entity ) where T:class
        {
            Console.WriteLine( "Add/2 overload #2" ) ;
        }
    }
    class Program
    {
        
        static int Main( string[] args )
        {
            MimeTable mt = new MimeTable() ;
            Widget    widget = new Widget() ;
            widget.Add( mt ) ;
            widget.Add( (IEnumerable<Mime>) mt ) ;
            return 0 ;
        }
    }   // program
