        #region Persons
        private ObservableCollection<PersonViewModel> _Persons;
        public ObservableCollection<PersonViewModel> Persons
        {
            get { return _Persons ?? (_Persons = GetAllPersons()); }
        }
        private ObservableCollection<PersonViewModel> GetAllPersons()
        {
            var toRet = new ObservableCollection<PersonViewModel>();
            foreach (var i in Enumerable.Range(1,10))
            {
                toRet.Add(new PersonViewModel {Name = string.Format("Person Name {0}", i)});
            }
            //!!!!!!!!!!!!!!!!!!!!!HERE I SET THE SELECTED ITEM
            SelectedPerson = toRet.First();
            return toRet;
        }
        #endregion
        #region SelectedPerson
        private PersonViewModel _SelectedPerson;
        private const string SelectedPersonName = "SelectedPerson";
        public PersonViewModel SelectedPerson
        {
            get { return _SelectedPerson; }
            set
            {
                Set(SelectedPersonName, ref _SelectedPerson, value);
            }
        }
        #endregion
