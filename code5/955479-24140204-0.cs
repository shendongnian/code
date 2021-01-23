        bool MoveOldestFolder(string initialFolderName, string destinationFolder)
        {
            // gets all top folders in your chosen location
            var directories = System.IO.Directory.EnumerateDirectories(initialFolderName,"*", System.IO.SearchOption.TopDirectoryOnly);
            
            // stores the oldest folder and it's date at the end of algorithm
            DateTime outDate;
            DateTime oldestDate = DateTime.MaxValue;
            string resultFolder = string.Empty;
    
            // just a temp variable
            string tmp;
    
            // using LINQ
            directories.ToList().ForEach(p =>
            {
                tmp = new System.IO.FileInfo(p).Name; // get the name of the current folder
                if (DateTime.TryParseExact(tmp,
                                           "yyyyMMdd",  // this is case sensitive!
                                           System.Globalization.CultureInfo.InvariantCulture,
                                           System.Globalization.DateTimeStyles.None, 
                                           out outDate)) // try using folder name as date that "should" be in yyyyMMdd format - if the conversion is successful and date is older than current outDate, then store folder name and date, else nothing
                {
                    if (outDate.Date < oldestDate.Date)
                    {
                        oldestDate = outDate;
                        resultFolder = p;
                    }
                }
            });
    
    
            // if we actually found a folder that is formatted in yyyyMMdd format
            if (!oldestDate.Equals(DateTime.MaxValue))
            {
                try
                {
                    System.IO.Directory.Move(resultFolder, destinationFolder);
                    
                    return true;
                }
                catch(Exception ex)
                {
                    // handle the excaption
                    return false;
                }
            }
            else
            {
                // we didnt find anything
                return false;
            }
        }
    private void button1_Click(object sender, EventArgs e)
    {
        var initialFolderName = @"C:\initial";
        var destinationFolder = @"c:\dest";
        if (MoveOldestFolder(initialFolderName, destinationFolder))
        {
            // move was successful                
        }
        else
        {
            // something went wrong
        }
    }
