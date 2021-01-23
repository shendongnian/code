    public class ServiceResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
    public ServiceResult InsertCoordinates(string param) 
    {
        // ... code
        try
        {
            sqlCon.Open();
            sqlCom.ExecuteNonQuery();
            return new ServiceResult() { Success = True };
        }
        catch (Exception ex)
        {
            return new ServiceResult() { Success = False, Message = "Crash & Burn!" }; 
        }
        // ... more code
    }
