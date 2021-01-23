    public ApDocument RetrieveApDocument(string filename) 
    {
        try
        {
            var info = GetFileInfo(filename);
            var newApDoc = BuildNewDocument(info);
            
            return newApDoc;
        }
        catch(InvalidFilenameException ex)
        {
            // decide what to do
        }
        // maybe catch the file parsing errors here
    }
    private FileInfo GetFileInfo(string filename)
    {
        try
        {
            var accountNumber = GetAccountNumber(filename);
            var docType = DetermineDocType(filename);
            return new FileInfo(accountNumber, docType);
        }
        catch(InvalidAccountNumberException ex)
        {
            // maybe log here or decide what to do next or not even catch these...
            throw new InvalidFilenameException("Filename: " + filename + " is not in the correct format", ex);
        }
        catch(InvalidDocumentTypeException ex)
        {
            throw new InvalidFilenameException("Filename: " + filename + " is not in the correct format", ex);
        }
    }
    private string GetAccountNumber(string filename) 
    {
        // whatever you do here - throw exception when error occurs
    }
    
    private string DetermineDocType(string filename) 
    {
        // whatever you do here - throw exception when error occurs
    }
    private ApDocument BuildNewDocument(FileInfo info)
    {
        
        // try / catch here if need be
        var doc = parser.FindData(file, docType);
        
        // set your other 'SendTo' and DeliveryType stuff here.
               
        return doc;    
    }
