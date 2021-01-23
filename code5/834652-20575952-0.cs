           string[] wordsArray = null;
           string s = string.Empty;
           string path = "file_1.txt";
           string[] lines = System.IO.File.ReadAllLines(path);
           foreach (string aLine in lines)
           {
                s = aLine.Replace("||", "|");
                wordsArray = s.Split('|');
                //now you have the question in wordsArray[0], and the answers in the following
                //array cells ([1],[2], etc.)
                //You can do what you want here, including building a 2-d array using wordsArray.
           }
