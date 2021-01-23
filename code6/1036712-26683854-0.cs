    public class ResponseObject
    {
        public string Key { get; set; }
        public List<Value> Value { get; set; }
    }
    
    public class Value
    {
        public int OrderID { get; set; }
        public int OrderItemID { get; set; }
        public int ProgramID { get; set; }
        public string ProgramName { get; set; }
        public string ProgramDescription { get; set; }
        public string ScheduleDate { get; set; }
        public string SubmitOrderRequestDate { get; set; }
        public string OrderTypeName { get; set; }
        public string OrderTypeDescription { get; set; }
        public object ProductID { get; set; }
        public object ProductName { get; set; }
        public object ProductDescription { get; set; }
        public object ProductHTMLTitle { get; set; }
        public string EditionName { get; set; }
        public int EditionID { get; set; }
        public string EditionDescription { get; set; }
        public object SpecialInstruction { get; set; }
        public string OrderDeliveryTypeName { get; set; }
        public string OrderDeliveryTypeDescription { get; set; }
        public string OrderItemStatusName { get; set; }
        public string OrderItemStatusDescription { get; set; }
        public string EditionStatus { get; set; }
        public string EditionStatusDescription { get; set; }
        public object OrderItemDeliveryStatusName { get; set; }
        public object OrderItemDeliveryStatusDescription { get; set; }
        public int OrderItemQuantity { get; set; }
        public object OrderItemDeliveryQuantityRequested { get; set; }
        public object OrderItemDeliveryID { get; set; }
        public object UploadedFlag { get; set; }
        public object AccessCode { get; set; }
        public object Created { get; set; }
        public object UseSecureBrowserFlag { get; set; }
        public string ExamName { get; set; }
        public int CohortID { get; set; }
        public string CohortName { get; set; }
        public int StudentCount { get; set; }
        public object ExamTypeProgramTypeID { get; set; }
        public int OrderItemApplicationID { get; set; }
        public object DBLockedByUserName { get; set; }
        public object AutoCodeEditionFlag { get; set; }
        public object WorkflowName { get; set; }
        public object WorkflowStatus { get; set; }
        public bool UseLastSyllabusFlag { get; set; }
        public int SyllabusID { get; set; }
        public object AssessmentTypeName { get; set; }
    }
