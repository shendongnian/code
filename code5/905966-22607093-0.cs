     public class UserInfoViewModel 
      {
        private ICollectionView _employeeCollectionView;
        public ICollectionView EmployeeCollectionView
        {
            get
            {
                return _employeeCollectionView;
            }
            private set { _employeeCollectionView = value; }
        }
      private void GetEmployee()
        {
         EmployeeCollectionView = CollectionViewSource.GetDefaultView(HERE-IS-YOUR-COLLECTION);
    
         EmployeeCollectionView.CurrentChanged += new EventHandler(_customerView_CurrentChanged);
       }
     void _customerView_CurrentChanged(object sender, EventArgs e)
        {
          var selectedEmployee= EmployeeCollectionView.CurrentItem as Employee;
        }
    }
