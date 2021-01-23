    public class OperationViewModel : ViewModelBase, IDataErrorInfo
        {
            private const int ConstCodeMinValue = 1;
            private readonly IEventAggregator _eventAggregator;
            private OperationInfoDefinition _operation;
            private readonly IEntityFilterer _contextFilterer;
            private OperationDescriptionViewModel _description;
    
            public long Code
            {
                get { return _operation.Code; }
                set
                {
                    if (SetProperty(value, _operation.Code, o => _operation.Code = o))
                    {
                        UpdateDescription();
                    }
                }
            }
    
            public string Description
            {
                get { return _operation.Description; }
                set
                {
                    if (SetProperty(value, _operation.Description, o => _operation.Description = o))
                    {
                        UpdateDescription();
                    }
                }
            }
    
            public string FriendlyName
            {
                get { return _operation.FriendlyName; }
                set
                {
                    if (SetProperty(value, _operation.FriendlyName, o => _operation.FriendlyName = o))
                    {
                        UpdateDescription();
                    }
                }
            }
        
            public int Timeout
            {
                get { return _operation.Timeout; }
                set
                {
                    if (SetProperty(value, _operation.Timeout, o => _operation.Timeout = o))
                    {
                        UpdateDescription();
                    }
                }
            }
    
            public string Category
            {
                get { return _operation.Category; }
                set
                {
                    if (SetProperty(value, _operation.Category, o => _operation.Category = o))
                    {
                        UpdateDescription();
                    }
                }
            }
    
            public bool IsManual
            {
                get { return _operation.IsManual; }
                set
                {
                    if (SetProperty(value, _operation.IsManual, o => _operation.IsManual = o))
                    {
                        UpdateDescription();
                    }
                }
            }
    
    
            void UpdateDescription()
            {
                //some code
            }
    
    
    
    
            #region Validation
    
    
    
    
            #region IDataErrorInfo
    
            public ValidationResult Validate()
            {
                return ValidationService.Instance.ValidateNumber(Code, ConstCodeMinValue, long.MaxValue);
            }
    
            public string this[string columnName]
            {
                get
                {
                    var validation = ValidationService.Instance.ValidateNumber(Code, ConstCodeMinValue, long.MaxValue);
    
                    return validation.IsValid ? null : validation.ErrorContent.ToString();
                }
            }
    
            public string Error
            {
                get
                {
                    var result = Validate();
                    return result.IsValid ? null : result.ErrorContent.ToString();
                }
            }
            #endregion
    
            #endregion
        }
