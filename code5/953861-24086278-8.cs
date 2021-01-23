    //Controller class
    public class ReportController : Controller {
        public ActionResult Index() {
            ActionResult result = null;
            ReportSelectionViewModel viewModel = this.BuildViewModel();
            result = View("Index", viewModel);
            return result;
        } // end action Index
        [HttpPost()]
        public ActionResult ChangeReport(ChangeReportRequest changeRequest) {
            ActionResult result = null;
            ReportSelectionViewModel viewModel = this.BuildViewModel();
            Session["ReportOptions"] = changeRequest;
            viewModel.Messages.Add("Selection was changed.");
            viewModel.ReportRequest = changeRequest;
            result = View("Index", viewModel);
            return result;
        } // end action ChangeReport
        //Method that encapsulates the logic needed to build a view model for actions on this controller
        protected ReportSelectionViewModel BuildViewModel() {
            ReportSelectionViewModel viewModel = null;
            viewModel = new ReportSelectionViewModel();
            viewModel.AvailableThresholds.AddRange(new int[] { 1, 2, 3, 4 });
            //Set the value to whatever the user previously selected if available
            if (Session["ReportOptions"] != null) {
                viewModel.ReportRequest.ThresholdSelect = ((ChangeReportRequest)Session["ReportOptions"]).ThresholdSelect;
            } // end if
            return viewModel;
        } // end function BuildViewModel
    } // end class ReportController
