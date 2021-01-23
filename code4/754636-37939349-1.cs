    using Microsoft.Phone.UserData;
    using System.Collections.ObjectModel;
    ObservableCollection<PhoneContact> phoneContact;
    public MainPage() {
         InitializeComponent();
         phoneContact = new ObservableCollection<PhoneContact>();
         ReadPhoneContact();
    }
   
    void ReadPhoneContact(){
         Contacts cnt = new Contacts();
         cnt.SearchCompleted += new EventHandler<ContactsSearchEventArgs>(Contacts_SearchCompleted);
         cnt.SearchAsync(String.Empty, FilterKind.None, "Contacts Test #1");
    }
