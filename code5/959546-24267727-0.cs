            //other code you have    
            List<List<string>> Threads = new List<List<string>>();
    
            public void Links(string FileName)
            {
    
          // ...other code you have
           for (int i = 0; i < FilteredLinks.Count; i++)
                {  
                   threads.Add(new List<string>);
                    contents.Encoding = System.Text.Encoding.GetEncoding(1255);
                    cont = contents.DownloadString(FilteredLinks[i]);
                    GetResponsers(threads[threads.Count - 1], cont);
                }
            }
    
         private void GetResponsers(List<string> threadList, string contents)
                    {
                        int f = 0;
                        int startPos = 0;
                        while (true)
                        {
                            string firstTag = "<FONT CLASS='text16b'>";
                            string lastTag = "&n";
                            f = contents.IndexOf(firstTag, startPos);
                            if (f == -1)
                            {
                                break;
                            }
                            int g = contents.IndexOf(lastTag, f);
                            startPos = g + lastTag.Length;
                            string responser = contents.Substring(f + firstTag.Length, g - f - firstTag.Length);
                            threadList.Add(responser);    
                        }   
                    }
