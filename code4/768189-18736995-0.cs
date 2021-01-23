    class Program
    {
        static readonly Regex re = new Regex( @"^name_.+_value_.+$", RegexOptions.Compiled );
        
        static void Main()
        {
            Console.WriteLine( re.Match( "name_Ford_value_Focus" ).Success.ToString() ); //True
           Console.WriteLine( re.Match( "name_value_Focus" ).Success.ToString() ); //False
       }
    }
