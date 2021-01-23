    [DataContract()]
    public class PersonListViewModel : BaseViewModel
    {
        [DataMember()]
        private List<string> PersonIds = new List<string>();
        public PersonListViewModel()
        {
            Persons = new ObservableCollection<PersonViewModel>();
            CreateDefaultData();
        }
        public void CreateDefaultData()
        {
            for(int i=0; i<3; i++)
            {
                string personid = Guid.NewGuid().ToString();
                string personname = "Person " + personid;
                PersonViewModel person = new PersonViewModel(personname);
                PersonIds.Add(personid);
                Persons.Add(person);
                SharedObjects.Instance.Objects[personid] = person;
            }
        }
        public void RefreshPersonCollection()
        {
            Persons = new ObservableCollection<PersonViewModel>();
            foreach (string personid in PersonIds)
            {
                Persons.Add((PersonViewModel)SharedObjects.Instance.Objects[personid]);
            }
        }
        public ObservableCollection<PersonViewModel> Persons{ get; set; }
    }
