    public class MyViewModel
    {
        public User User { get; set; }
        public OtherModel Model { get; set; }
        public bool IsSomethingHere
        {
            get
            {
                return (User.isHelpDesk && Model.MaterialStatusId == MatStatus.A1HelpDeskProductProposal) ||
                    (User.isProcurement && Model.MaterialStatusId == MatStatus.A4PurchasingDptValidation);
            }
        }
        public bool IsSomethingElseHere
        {
            get
            {
                return User.isHelpDesk || User.isProcurement || User.isDirector || User.isManager;
            }
        }
    }
