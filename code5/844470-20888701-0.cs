    [DataContract()]
    public class PersonViewModel : BaseViewModel
    {
        public PersonViewModel(string name)
        {
            Name = name;
        }
        #region Name property
        [DataMember()]
        private string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                SetPropertyValue(ref _Name, value, () => Name);
            }
        }
        #endregion
    }
