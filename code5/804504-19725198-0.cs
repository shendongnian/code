    static void Main(string[] args)
            {
                Console.WriteLine(checkString("137563475634c756"));
            }
            static  public bool checkString(String s)
            {
                return Regex.IsMatch(s, "[a-zA-Z]");
            }
