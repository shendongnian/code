    class Program
    {
        static readonly Regex re = new Regex( @"^public partial class[^:]+$", RegexOptions.Compiled );
        static string Replacement( string stringToReplace )
        {
            return re.Replace( stringToReplace, match => match.Value + ": IEntity" );                
        }   
        static void Main()
        {
            string newString = Replacement( "public partial class Client" );
            Console.WriteLine( newString ); //output: "public partial class Client: IEntity"
            newString = Replacement( "public partial class Server" );
            Console.WriteLine( newString ); //output: "public partial class Server: IEntity"
            newString = Replacement( "public partial class Server: IEntity" );
            Console.WriteLine( newString ); //output: "public partial class Server: IEntity"
        }       
    }
