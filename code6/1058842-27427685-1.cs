    public class PersonViewModel : ViewModelBase
    {
        #region Name
        private string _Name;
        private const string NameName = "Name";
        public string Name
        {
            get { return _Name; }
            set
            {
                Set(NameName, ref _Name, value);
            }
        }
        #endregion
    }
