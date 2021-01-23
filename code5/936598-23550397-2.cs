    public int Do(DoRequest request)
    {
        var response = new DoResponse();
        try
        {
            response.num = int.Parse(request.str);
        }
        catch (Exception ex)
        {
             // Log here;
             response.Error = ex.Message;                
        }
        return response;
    }
    
