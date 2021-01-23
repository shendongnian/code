    class Program
    {
        static readonly Regex re = new Regex( @"HDKLFKEHR(.+)LDKFRLEK", RegexOptions.Compiled );                        
        static void Main()
        {            
            Match match = re.Match( "HDKLFKEHR######LDKFRLEK"  );
            if( match.Success )
            {
                var innerText = match.Groups[1].ToString();
                Console.WriteLine( innerText ); //######
            }
    }
