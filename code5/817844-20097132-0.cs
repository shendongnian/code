            string file =@"D:\STACKOVERFLOW\csvproblem.txt";            
            string newfile =@"D:\STACKOVERFLOW\output.txt";
            StreamReader sr = new StreamReader(file);
            StreamWriter sw = new StreamWriter(newfile);
            
            try{
                string header = "";
                StringBuilder sb = new StringBuilder();
                StringBuilder sb_header = new StringBuilder();
                bool recordHeader = true;
                while(sr.EndOfStream==false){
                    string readLine = sr.ReadLine();
                    string[] split = readLine.Split(',');
                    sb = new StringBuilder();
                    foreach (string str in split)
                    {
                        if (recordHeader)
                        {
                            if (str.IndexOf('$') < str.LastIndexOf('$'))
                            {
                               sb_header.AppendFormat("{0},",
                                   str.Substring(str.IndexOf('$'),str.IndexOf('$')+str.LastIndexOf('$')+1));
                            }
                        }
                        sb.AppendFormat("{0},", str.Substring(str.IndexOf('=')+1));
                    }
                    if (recordHeader)
                    {
                        sw.WriteLine(sb_header.ToString().Trim(','));
                    }
                    sw.WriteLine(sb.ToString().Trim(','));
                    recordHeader = false;
                }
            }
            finally{
                sr.Close();
                sw.Close();
            }
