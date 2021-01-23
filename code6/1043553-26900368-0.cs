    using System.Threading.Tasks;
    // read the specific file into a string buffer
    private async Task<string> ReadFileIntoBuffer(string fileName)
    {
        string buffer = "";                                                                  // our buffer
        StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;           // local folder
        var folder = await local.GetFolderAsync("DataFolder");                               // sub folder
        // open the file for reading                        
        using (Stream s = await folder.OpenStreamForReadAsync(fileName))
        {
            using (StreamReader sr = new StreamReader(s))
            {
                buffer = await sr.ReadToEndAsync();
            }
        }
        // return the buffer
        return buffer;
    }
    // write the string buffer to a specific file
    private async Task<bool> WriteBufferToFile(string fileName, string buffer)
    {
        try
        {
            StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;           // local folder
            var folder = await local.GetFolderAsync("DataFolder");                               // sub folder
            // open the file for writing
            using (Stream s = await folder.OpenStreamForWriteAsync(fileName, CreationCollisionOption.ReplaceExisting))
            {
                using (StreamWriter sw = new StreamWriter(s))
                {
                    await sw.WriteAsync(buffer);
                }
            }
        }
        catch (Exception ex)
        {
            string error_message = ex.Message;
            return false;
        }
        
        return true;
    }
----------
    
    // New Delete Lines function based off your old one
    private string DeleteLines(string input_buffer, int id)
    {
        string output_buffer = "";
        using (StringReader sr = new StringReader(input_buffer))
        {
            while (true)
            {
                string line = sr.ReadLine();
                if (line != null)
                {
                    if (String.Compare(line, id.ToString()) == 0)
                    {
                    }
                    else
                    {
                        // add it to the output_buffer plus the newline
                        output_buffer += (line + "\n");
                    }
                }
                else
                {
                    break;
                }
            }
            
        }
        return output_buffer;
    }
