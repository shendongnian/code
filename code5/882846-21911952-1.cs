    try
    {
        client.Exception();
        client.Close();
    }
    catch (FaultException<ExceptionDetail> ex)
    { 
        // handle it; ex.Detail contains the server exception data
    }
