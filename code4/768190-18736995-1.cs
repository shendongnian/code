    class Program
    {
        static void Main()
        {
            string pattern = @"^name_.+_value_.+$";
            Console.WriteLine( Regex.Match( "name_Ford_value_Focus", pattern ).Success.ToString() );//true
            Console.WriteLine( Regex.Match( "name_value_Focus", pattern ).Success.ToString() );//false        
        }
    }
