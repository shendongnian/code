    public class DepartmentViewModel : IDataErrorInfo, INotifyPropertyChanged
    {
        private Department _model;
    
        public DepartmentViewModel(Department model)
        {
            _model = model;
            Validator = new DepartmentValidator();
        }
    
        public DepartmentValidator Validator { get; set; }
    
        public string DepartmentFullName
        {
            get
            {
                return _model.DepartmentFullName;
            }
            set
            {
                if(_model.DepartmentFullName != value)
                {
                    _model.DepartmentFullName = value;
                    this.OnPropertyChanged("DepartmentFullName");
                }
            }
        }
    
        public string DepartmentCode
        {
            get
            {
                return _model.DepartmentCode;
            }
            set
            {
                if(_model.DepartmentCode != value)
                {
                    _model.DepartmentCode = value;
                    this.OnPropertyChanged("DepartmentCode");
                }
            }
        }
    
        public int DepartmentId
        {
            get
            {
                return _model.DepartmentId;
            }
        }
    
        public string this[string columnName]
        {
            get
            {
                var errors = Validator.Validate(_model) ?? new List<ValidationError>();
                if (errors.Any(p => p.Property == columnName))
                {
                    return string.Join(Environment.NewLine, errors.Where(p => p.Property == columnName).Select(p => p.ErrorDescription));
                }
                return null;
            }
        }
    
        public string Error
        {
            get
            {
                var errors = Validator.Validate(_model) ?? new List<ValidationError>();
                return string.Join(Environment.NewLine, errors);
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
