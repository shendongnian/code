    private string GetResponse(string req)
    {
        try
        {
            using (var proxy = new MapperProxy())
            {
                return proxy.Map(null, req);
            }
        }
        catch (FaultException fe)
        {
            switch (fe.Code.Name)
            {
                case "BAD REQUEST":
                    return "400 BAD REQUEST - " + fe.Message;
                case "FORBIDDEN":
                    return "403 FORBIDDEN - " + fe.Message;
                default:
                    return "501 INTERNAL SERVER ERROR: " + fe.Message;
            }
        }
        catch (Exception ex)
        {
            return "Exception caught: " + ex.ToString();
        }
    }
