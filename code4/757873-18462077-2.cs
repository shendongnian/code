        public class TransactionHistoryModel
        {
            public int statusid { get; set; }
            public int TypeofId { get; set; }
            public string Status { get; set; }
            public IEnumerable<SelectListItem> StatusList { get; set; }
            public string TypeOfChange { get; set; }
            public IEnumerable<SelectListItem> TypeOfChangeList { get; set; }
        }
