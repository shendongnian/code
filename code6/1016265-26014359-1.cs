            using System.Text;
            namespace ConsoleApplication11
            {
                class Program
                {
                    static void Main(string[] args)
                    {
                        bool isMatch = "this is text ".RegexMatch(@"\bis\b").Success;
                    }
                }
            }
