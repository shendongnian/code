    public class PersonViewModel : IDataErrorInfo 
    {
        [Required(AllowEmptyStrings = false)]
        public string Name
        {
            get
            {
                 return _person.Name
            }
            set
            {
                 _person.Name = value;
            }
        }    
        public string Error
        {
            get { throw new NotImplementedException(); }
        }
    
        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                return OnValidate(propertyName);
            }
        }
    
        protected virtual string OnValidate(string propertyName)
        {
            /* ... */
        }
    }
