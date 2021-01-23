     public class MainViewModel : ViewModelBase
    {
        #region Properties and Fields
        /// <summary>
        /// A collection of user records.
        /// </summary>
        private ObservableCollection<UserInfomation> users;
        /// <summary>
        /// Command to execute when a record is to be edited.
        /// </summary>
        public RelayCommand<UserInfomation> EditUserDetail { get; private set; }
        /// <summary>
        /// Command to execute when a record is to be saved.
        /// </summary>
        public RelayCommand<UserInfomation> SaveUserDetail { get; private set; }
        /// <summary>
        /// Holds the current data that is being edited, if any.
        /// </summary>
        private UserInfomation userDataInEditMode;
        #endregion
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            this.EditUserDetail = new RelayCommand<UserInfomation>(EditUserDetailAction);
            this.SaveUserDetail = new RelayCommand<UserInfomation>(SaveUserDetailAction);
            this.GenerateData();
        }
        #region Public Properties
        public ObservableCollection<UserInfomation> Users
        {
            get { return this.users; }
            set
            {
                if (this.users != value)
                {
                    this.users = value;
                    this.RaisePropertyChanged();
                }
            }
        }
        #endregion
        #region Methods
        private void GenerateData()
        {
            this.Users = new ObservableCollection<UserInfomation>
            {
                new UserInfomation { FirstName = "John", LastName = "Smith", AddressLineOne = "1 John Avenue, Florida" },
                new UserInfomation { FirstName = "Peter", LastName = "Wandsworth", AddressLineOne = "34 Peter Avenue, Denver" },
                new UserInfomation { FirstName = "Emily", LastName = "Stone", AddressLineOne = "1 Emily Avenue, London" }
            };
        }
        private void EditUserDetailAction(UserInfomation userDataToEdit)
        {
            if (userDataInEditMode != null)
            {
                this.userDataInEditMode.EditMode = false;
            }
            this.userDataInEditMode = userDataToEdit;
            this.userDataInEditMode.EditMode = true;
        }
        private void SaveUserDetailAction(UserInfomation userDataToSave)
        {
            //Save your data here:
            if (userDataInEditMode != null)
            {
                userDataInEditMode.EditMode = false;
                MessageBox.Show("first name changed to " + userDataToSave.FirstName);
            }
        }
        #endregion
    }
