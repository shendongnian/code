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
