    public enum ErrorCode
    {
       NoError,
       DatabaseError,
       UnknownError,
       OutofrangeError
    }
    [WebMethod]
    public ErrorCodes insertCoordinates(string param) 
    {
        ErrorCodes result = ErrorCodes.NoError;
        try
        {
            BLL bll = new BLL();
            bool dbResult = bll.InsertCoordinates(param);
            if (!dbResult) {result = ErrorCodes.DatabaseError;}
        }
        catch (OutOfRangeException ex) {result = ErrorCodes.OutofrangeError;}
        catch (Exception ex) {result = ErrorCodes.UnknownError;}
        return result;
    }
