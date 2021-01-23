    try
    {
        using (FileStream fs = File.Open(sender.fileName, FileMode.Open))
        using (BinaryReader br = new BinaryReader(fs))
        {        
            //read in header from file.
            if ( /*header shows wrong file format*/ )
            {     
                isWrongFormat = true;
                MessageBox.Show("Wrong format.");
                ErrorInFileReadEventHandler(this, null);
            }
            else
            {
                //read rest of file.
                SuccessfulFileReadEventHandler(this, null);
            }
        }
    }
    catch
    {
        MessageBox.Show("Couldn't access.");
        ErrorInFileReadEventHandler(this, null);
    }
