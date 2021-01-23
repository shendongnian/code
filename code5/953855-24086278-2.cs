    //Controller class
    public class ReportController : Controller {
        //
        // GET: /My/
        protected ReportSelectionViewModel BuildViewModel() {
            ReportSelectionViewModel viewModel = null;
            viewModel = new ReportSelectionViewModel();
            viewModel.AvailableThresholds.AddRange(new int[] { 1, 2, 3, 4 });
            //Set the value to whatever the user previously selected if available
            if (Session["ReportOptions"] != null) {
                viewModel.ReportRequest.ThresholdSelect = ((ChangeReportRequest)Session["ReportOptions"]).ThresholdSelect;
            }
            return viewModel;
        } // end function BuildViewModel
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
    } // end class ReportController
    //Model class that gets built by the DefaultModelBinder
    public class ChangeReportRequest {
        private int _reportId;
        private int _thresholdSelect;
        public ChangeReportRequest() {
            _reportId = 1; // Meaningful default value here
            _thresholdSelect = 0;
        } // end constructor
        public int ReportId {
            get {
                return _reportId;
            } set {
                _reportId = value;
            }
        } // end property ReportId
        public int ThresholdSelect {
            get {
                return _thresholdSelect;
            } set {
                _thresholdSelect = value;
            }
        } // end property ThresholdSelect
    } // end class ChangeReportRequest
    //Strongly typed view model class passed to the view to add intellisense support in the view and avoid the ViewBag.
    using System.Collections.Generic;
    public class ReportSelectionViewModel {
        private List<int> _availableThresholds;
        private List<string> _messages;
        private ChangeReportRequest _reportRequest;
        public ReportSelectionViewModel() {
            _availableThresholds = new List<int>();
            _messages = new List<string>();
            _reportRequest = new ChangeReportRequest();
        } // end constructor
        public List<int> AvailableThresholds {
            get {
                return _availableThresholds;
            }
        } // end property AvailableThresholds
        public List<string> Messages {
            get {
                return _messages;
            }
        } // end property Messages
        public ChangeReportRequest ReportRequest {
            get {
                return _reportRequest;
            } set {
                if (value != null) {
                    _reportRequest = value;
                } // end if
            }
        } // end property ReportRequest
    } // end class ReportSelectionViewModel
