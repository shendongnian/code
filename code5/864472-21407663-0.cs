    public class ActionExecutedFilter : System.Web.Mvc.ActionFilterAttribute
    {
        UnitOfWork unitOfWork= new UnitOfWork();
        public override void OnActionExecuted(ActionExecutedContext filter)
        {
            Transaction tran = new Transaction();
            tran.Controller = filter.ActionDescriptor.ControllerDescriptor.ControllerName;
            tran.ActionName = filter.ActionDescriptor.ActionName;
            tran.User = HttpContext.Current.User.Identity.Name;
            tran.Date = DateTime.Now;
            unitOfWork.TransactionRepository.Insert(tran);
            unitOfWork.Save();
        }
    }
