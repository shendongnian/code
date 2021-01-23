     private  String GetFooter(String filePath)
            {
                
                String inputText = "#Footer";
                String footerText ="";
                String [] allFileLines=(String[])File.ReadLines(filePath).ToArray();
                int footerLineNo = -1;
                for (int i = 0; i < allFileLines.Length; i++)
                {
                    if (allFileLines[i].Contains(inputText))
                        footerLineNo = i;
                }
    
                if (footerLineNo > -1)
                {
                    for (int i = footerLineNo + 1; i < allFileLines.Length; i++)
                        footerText += allFileLines[i]+"\n";
                }
                return footerText;
            }
