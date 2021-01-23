    Regex.Replace(File.ReadAllText(@"C:\MyIniFile.txt"),  // Read all lines into buffer.
                   @"(Upper1=0)(.*)(\[HRData\])",         // Set upper to HRData to be removed
                   string.Empty,                          // 'replace' the section with a empty line
                   RegexOptions.Singleline)
          .Split(new[] { "\r\n", "\r", "\n" },           // Split the remaining buffer into lines
                 StringSplitOptions.RemoveEmptyEntries); // Don't show empty lines.
