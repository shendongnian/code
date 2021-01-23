    class Program
    {
        static void Main()
        {
            string pattern = @"^name_.+_value_.+$";
            Console.WriteLine( Regex.Match( "name_Ford_value_Focus", pattern ).Success.ToString() );//true
            Console.WriteLine( Regex.Match( "name_value_Focus", pattern ).Success.ToString() );//false
            //Other examples:
            Console.WriteLine( Regex.Match( "name_Toyota_value_Corolla", pattern ).Success.ToString() );//true
            Console.WriteLine( Regex.Match( "name_Mini_value_", pattern ).Success.ToString() );//false
            Console.WriteLine( Regex.Match( "Applename_Ford_value_FocusApple", pattern ).Success.ToString() );//false because full string match. Remove ^ and $ from pattern for true
        
        }
    }
