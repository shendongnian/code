    public class Program
    {
    
        const string input = "BEGIN:VCARD\nVERSION:2.1FN:Peter StoddartADR:My School (BranchName)TEL;CELL:00129222273645EMAIL;HOME;INTERNET:abc@gmail.comREV:3757END:VCARD";        
        
        public static void Main(string[] args)
        {
            Regex expression = new Regex(@"REV:(?<SearchID>[\d]+)END");
            var match = expression.Match(input);
            if (match.Success)
            {
                Console.WriteLine(match.Groups["SearchID"].Value);
                
            }
        }
    }
