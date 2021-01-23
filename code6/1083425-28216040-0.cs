     public static void Main()
     {
       string input = "This is   text with   far  too   much   " + 
                      "whitespace.";
       string pattern = "\\s+";
       string replacement = " ";
       Regex rgx = new Regex(pattern);
       string result = rgx.Replace(input, replacement);
       Console.WriteLine("Original String: {0}", input);
       Console.WriteLine("Replacement String: {0}", result);                             
     }
