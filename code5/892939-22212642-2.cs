    public class EmailRecord
    {
    public string EmailAddress{ get; set; }
    }
    public List<EmailRecord> EmployeeAccess2()
    {
    EmployeeAccess EA = new EmployeeAccess();
    View_HCM VH = new View_HCM();
    var x = from b in contxt.View_HCM
            where b.EmpNo == EA.EmpNo
            select new EmailRecord
    {
    	EmailAddress = b.EmailAddress
    };
    return x.ToList();
    }
