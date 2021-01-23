    public interface IApprove // Defines a set of functionality that a class must implement.
    {
        // All these properties must be inherited as public when implemented.
        bool Approved { get; set; } // Property declaration.
        DateTime ApprovedDate { get; set; }
        int ApprovedUserId { get; set; }
    }
    public class Student : Person, IApprove
    {
        public DateTime DateOfBirth { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string Remarks { get; set; }
        #region IApprove Implementation
        private bool _approved; // Private variable that is accessed through the 'Approved' property of the 'IApprove' interface.
        public bool Approved // Defines 'Approved' inherited from IApprove
        {
            get { return _approved; }
            set { _approved = value; }
        }
        private DateTime _approvedDate;
        public DateTime ApprovedDate // Defines 'ApprovedDate' inherited from IApprove.
        {
            get { return _approvedDate; }
            set { _approvedDate = value; }
        }
        private int _approvedUserId;
        public int IApprove.ApprovedUserId // Alternative syntax to define an interfaces property.
        {
            get { return _approvedUserId; }
            set { _approvedUserId = value; }
        }
        #endregion
    }
