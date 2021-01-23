    public class RegistrationWizardController : BaseController
    {
        public ActionResult AnAction()
        {
            var student = this.GetCurrentStudentInfo(); //calls the method inherited from BaseController
        }
    }
