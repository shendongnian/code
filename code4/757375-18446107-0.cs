    public partial class Form1 : Form
    {
        private ADClassNew _adClassNew {get; set;}
        public Form1()
        {
            InitializeComponent();
            _adclassnew = new ADClassNew();
            _adclassnew.LdapPath = "LDAP://MyDomain";
            _adclassnew.SearchedObjClass = "User";
            _adclassnew.SearchedProp = "Displayname";
            _adclassnew.SearchedPropValue = "administrator";
        }
    }
