        static void Main(string[] args)
        {
            string uniCaption = Guid.NewGuid().ToString();
            Word.Application oWordApp = new Word.Application();
            oWordApp.Caption = uniCaption;
            oWordApp.Visible = true;
            Process pWord = getWordProcess(uniCaption);
            
            //If you don't want to show the Word windows
            oWordApp.Visible = false;
            
            //Do other things like open document etc.
        }
        static Process getWordProcess(string pCaption)
        {
            Process[] pWords = Process.GetProcessesByName("WINWORD");
            foreach (Process pWord in pWords)
            {
                if (pWord.MainWindowTitle == pCaption)
                {
                    return pWord;
                }
            }
            return null;
        }
