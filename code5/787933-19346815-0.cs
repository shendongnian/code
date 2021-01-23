    public class ContactsViewModel : ViewModelBase
    {
        private static IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;
        private List<UserContact> _contactList;
        public ContactsViewModel()
        {
            Contacts cons = new Contacts();
            cons.SearchAsync(String.Empty, FilterKind.None, null);
            cons.SearchCompleted += new EventHandler<ContactsSearchEventArgs>(OnContactSearchCompleted);
            SaveSavedContactsCommand = new RelayCommand(OnSaveSavedContacts);
        }
        public RelayCommand SaveSavedContactsCommand { get; private set; }
        private void OnSaveSavedContacts()
        {
            if (!Contacts.Any(x => x.IsSelected == true))
            {
                MessageBox.Show("Please select some contacts and then click on Save button.");
            }
            else
            {
                var selectedSavedContacts = Contacts.Where(x => x.IsSelected == true).Select(x => new SavedContact{ Name = x.Contact.DisplayName, PhoneNumber = x.Contact.PhoneNumbers.ElementAt(0).PhoneNumber}).ToList();
                SavedContacts = selectedSavedContacts;
                MessageBox.Show("Emergency contact list added successfully.");
                App.RootFrame.GoBack();
            }
        }
        void OnContactSearchCompleted(object sender, ContactsSearchEventArgs e)
        {
            try
            {
                Contacts = new List<UserContact>();
                var allContacts = new List<Contact>(e.Results.Where(x => x.PhoneNumbers.Count() > 0).OrderBy(c => c.DisplayName));
                foreach (Contact contact in allContacts)
                {
                    UserContact SavedContact = new UserContact() { Contact = contact };
                    if (SavedContacts.Any(x => x.PhoneNumber == contact.PhoneNumbers.ElementAt(0).PhoneNumber))
                    {
                        SavedContact.IsSelected = true;
                    }
                    else
                    {
                        SavedContact.IsSelected = false;
                    }
                    Contacts.Add(SavedContact);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error in retrieving contacts : " + ex.Message);
            }
        }
        [DataMember]
        public List<UserContact> Contacts
        {
            get { return _contactList; }
            set
            {
                _contactList = value;
                RaisePropertyChanged("Contacts");
            }
        }
        public List<SavedContact> SavedContacts
        {
            get
            {
                if (appSettings.Contains("SavedContacts"))
                {
                    var savedContacts = (List<SavedContact>)IsolatedStorageSettings.ApplicationSettings["SavedContacts"];
                    return savedContacts;
                }
                else
                {
                    return new List<SavedContact>();
                }
            }
            set
            {
                if (value != null)
                {
                    IsolatedStorageSettings.ApplicationSettings["SavedContacts"] = value;
                    IsolatedStorageSettings.ApplicationSettings.Save();
                }
            }
        }
    }
    public class SavedContact
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
    [DataContract]
    public class UserContact : INotifyPropertyChanged
    {
        public UserContact() { }
        private bool _isSelected;
        private Contact _contact;
        [DataMember]
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged("IsSelected");
                }
            }
        }
        [DataMember]
        public Contact Contact
        {
            get
            {
                return _contact;
            }
            set
            {
                if (_contact != value)
                {
                    _contact = value;
                    OnPropertyChanged("Contact");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
