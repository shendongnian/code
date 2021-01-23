    // DOS command line
    C:\>ConsoleApplication1 "Subject Line Text" "Some body text"
    // Web form code-behind
    // Pass subject and message strings as params to console app    
    ProcessStartInfo info = new ProcessStartInfo();
        
    string arguments = String.Format(@"""{0}"" ""{1}""",
         subjectText.Text.Replace(@"""", @""""""),
         messageText.Text.Replace(@"""", @""""""));
         info.FileName = MAILER_FILEPATH;
    
    Process process = Process.Start(info.FileName, arguments);
    Process.Start(info);
    // Console application
    static void Main(string[] args)
    {
        if (args.Length >= 2)
        {
            // Do stuff 
        }
    }
