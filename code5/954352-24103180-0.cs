    public class EmployeeResponse
    {
       public EmployeeResponse()
       {
       }
       public EmployeeResponse(EmployeeRequest e)
       {
           this.EmployeeResponseLicenseKey = e.EmployeeRequestLicenseKey+"_Response";
       }
       [MessageHeader(Namespace = "http://Chiranjib_VAIO.com/")]
       public string EmployeeResponseLicenseKey { get; set; 
       public Employee Employee { get; set ; }
    }
