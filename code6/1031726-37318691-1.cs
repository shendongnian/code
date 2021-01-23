    public class DashboardController : SessionController
    {
        SessionController.UserContext.Employee_ID = "1";//Assign Value
        var empId =   SessionController.UserContext.Employee_ID; //Use Value
        ....
    }
