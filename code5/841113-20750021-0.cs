                string Doc1Read  = //read from english file
                string Doc2Read = // read from Spanish file
                
                
                    string exp = @"[\w\s\n\r\t\.\(\)\,\[\]\-\;\:\%\@\#]*(?=&&&&)";
                    
                    var Doc1matches = Regex.Matches(Doc1Read, exp);
                    var Doc2matches = Regex.Matches(Doc1Read, exp);
                    for (int i = 0; i < Doc1matches.Count; i++)
                    {
                        **// open third document file and write** 
                        Doc1matches[i].Value; // write english version of page i
                        Doc2matches[i].Value; // write spanish version of page i
                       
                    }
