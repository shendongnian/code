    public class DevicesController : Controller
    {
        public ActionResult Manage(string currentPage)
        {
            return process_device_list(currentPage);
        }
        //this method was created as a result of code re-factoring since it is used in several other action methods not shown here
        private ActionResult process_device_list(string currentPage, bool redirect = false)
        {
            int count = 0;
            int page = 1;
            if (!int.TryParse(currentPage, out page))
            {
                if (!string.IsNullOrEmpty(currentPage))
                    return RedirectToAction("Manage");
                page = 1;
            }
            var model = new DeviceManagementListModel();
            model.Devices = BusinessFactory.DevicesLogic.GetAllDevices(page, out count);
            model.ActualCount = count;
            model.CurrentPage = page;
            if (!redirect)
                return View(model);
            else
                return RedirectToAction("Manage", new { @currentPage = currentPage });
        }
    }
