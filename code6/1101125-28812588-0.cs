    public partial class Form1 : Form, INotifyPropertyChanged {
        public string FirstName { get { return txtFirstName.Text; } set { txtFirstName.Text = value; } }
        public string LastName { get { return txtLastName.Text; } set { txtLastName.Text = value; } }
        public string NickName { get { return txtNickName.Text; } set { txtNickName.Text = value; } }
        public Form1() {
            InitializeComponent();
            UpdateNickName();
            txtFirstName.TextChanged += (s, e) => FirePropertyChanged("FirstName");
            txtLastName.TextChanged += (s, e) => FirePropertyChanged("LastName");
            txtNickName.TextChanged += (s, e) => FirePropertyChanged("NickName");
            PropertyChanged += Form1_PropertyChanged;
        }
        void Form1_PropertyChanged(object sender, PropertyChangedEventArgs e) {
            switch(e.PropertyName) {
                case "FirstName":
                case "LastName":
                    UpdateNickName();
                    break;
            }
        }
        void UpdateNickName() {
            if(FirstName.Length > 1 && LastName.Length > 4) {
                NickName = FirstName.Substring(0, 1) + "" + LastName.Substring(0, 4);
            } else {
                NickName = "";
            }
        }
        public void FirePropertyChanged([CallerMemberName] string property = "") {
            if(PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
