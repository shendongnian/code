     public class UserInfomation : ObservableObject
    {
        #region Properties and Fields
        private string firstName;
        private string lastName;
        private string addressLineOne;
        private bool editMode;
        #endregion
        #region Public Properties
        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (this.firstName != value)
                {
                    this.firstName = value;
                    this.RaisePropertyChanged();
                }
            }
        }
        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (this.lastName != value)
                {
                    this.lastName = value;
                    this.RaisePropertyChanged();
                }
            }
        }
        public string AddressLineOne
        {
            get { return this.addressLineOne; }
            set
            {
                if (this.addressLineOne != value)
                {
                    this.addressLineOne = value;
                    this.RaisePropertyChanged();
                }
            }
        }
        public bool EditMode
        {
            get { return this.editMode; }
            set
            {
                if (this.editMode != value)
                {
                    this.editMode = value;
                    this.RaisePropertyChanged();
                }
            }
        }
        #endregion
    }
