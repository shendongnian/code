            //open the text file for reading
            using (TextReader tr = new StreamReader("Filepath"))
            {
                try
                {
                    // read line from text file
                    string query = tr.ReadLine();
                    // split the string on the commas to make it easier to find the key value
                    string[] queryArray = query.Split(',');
                    int beginingOfKeyIndex = queryArray[8].IndexOf('\'') + 1; // add one because we don't want the '
                    // get the key value from the correct array element
                    string keyValue = queryArray[8].Substring(beginingOfKeyIndex, queryArray.Length - beginingOfKeyIndex);
                }
                catch (IOException)
                {
                    // we get here when it tries to read beyond end of file or there is some other issue.
                    throw;
                }
            }
