    class YearModel : INotifyPropertyChanged
    {
        #region Members
        Year _year;
        #endregion
        #region Properties
        public Year Year
        {
            get { return _year; }
        }
        public Int32 id
        {
            get { return Year.id; }
            set
            {
                Year.id = value;
                NotifyPropertyChanged("id");
            }
        }
        public String Code
        {
            get { return Year.Code; }
            set
            {
                Year.Code = value;
                NotifyPropertyChanged("Code");
            }
        }
        public String Description
        {
            get { return Year.Description; }
            set
            {
                Year.Description = value;
                NotifyPropertyChanged("Description");
            }
        }
        public DateTime DateCreated
        {
            get { return Year.DateCreated; }
            set
            {
                Year.DateCreated = value;
                NotifyPropertyChanged("DateCreated");
            }
        }
        public Int32 CreatedByID
        {
            get { return Year.CreatedByID; }
            set
            {
                Year.CreatedByID = value;
                NotifyPropertyChanged("CreatedByID");
            }
        }
        public String CreatedByDesc
        {
            get { return Year.CreatedByDesc; }
            set
            {
                Year.CreatedByDesc = value;
                NotifyPropertyChanged("CreatedByDesc");
            }
        }
        public DateTime DateEdited
        {
            get { return Year.DateEdited; }
            set
            {
                Year.DateEdited = value;
                NotifyPropertyChanged("DateEdited");
            }
        }
        public Int32 EditedByID
        {
            get { return Year.EditedByID; }
            set
            {
                Year.EditedByID = value;
                NotifyPropertyChanged("EditedByID");
            }
        }
        public String EditedByDesc
        {
            get { return Year.EditedByDesc; }
            set
            {
                Year.EditedByDesc = value;
                NotifyPropertyChanged("EditedByDesc");
            }
        }
        #endregion
        #region Construction
        public YearModel()
        {
            this._year = new Year
            {
                id = 0,
                Code = "",
                Description = "",
                DateCreated = new DateTime(1900, 01, 01, 00, 00, 00),
                CreatedByID = 0,
                CreatedByDesc = "",
                DateEdited = new DateTime(1900, 01, 01, 00, 00, 00),
                EditedByID = 0,
                EditedByDesc = ""
            };
        }
        #endregion
        #region Property Change Events
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion
        #region Commands
        public ICommand EditCommand
        {
            get { return new RelayCommand(EditYear); }
        }
        public ICommand AddCommand
        {
            get { return new RelayCommand(AddYear); }
        }
        #endregion
        #region Functions
        public void EditYear()
        {
            try
            {
                Service1Client service = new Service1Client();
                Year y = new Year();
                y.id = this.id;
                y.Code = this.Code;
                y.Description = this.Description;
                y.DateEdited = DateTime.Now;
                y.EditedByID = (Int32)Application.Current.Resources["UserID"];
                service.EditYear(y);
                MessageBox.Show("Your Year was edited successfully", "Success", MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                logError le = new logError();
                le.log(ex, "YearViewModel", "EDIT");
            }
        }
        public void AddYear()
        {
            try
            {
                Service1Client service = new Service1Client();
                Year y = new Year();
                y.Code = this.Code;
                y.Description = this.Description;
                y.DateCreated = DateTime.Now;
                y.CreatedByID = (Int32)Application.Current.Resources["UserID"];
                y.DateEdited = this.DateEdited;
                service.AddYear(y);
                MessageBox.Show("Your new Year was entered successfully", "Success", MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                logError le = new logError();
                le.log(ex, "YearViewModel", "ADD");
            }
        }
        #endregion
    }
}
    <Button Content="Save New" 
      DataContext="{StaticResource ResourceKey=NewYear}" 
      Command="{Binding Path=AddCommand}"/>
    class RelayCommand : ICommand
    {
        Action action;
   
        public RelayCommand(Action execute)
        {
            action = execute;
        }
    
        public bool CanExecute(object parameter)
        {
            return true;
        }
   
        public event EventHandler CanExecuteChanged;
    
        public void Execute(object parameter)
        {
            action();
        }
    }
                
