        public partial class Popup : Form
        {
         public bool isOpen;
         public ListBox PopupListBox;
         public Popup()
         {
            InitializeComponent();
         }
         void Popup_FormClosing(object sender, FormClosingEventArgs e)
         {
            isOpen = false;
         }
         private void Popup_Load(object sender, EventArgs e)
         {
            this.FormClosing += Popup_FormClosing;
            PopupListBox = popupListBox;
         }
     }
