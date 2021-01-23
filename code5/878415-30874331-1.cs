    public partial class MainForm: Form {
        ElementHost SubjectTBox = new ElementHost();
        
        public MainForm() {
            InitializeComponent();
            SubjectTBox.Size = new Size(545, 20);
            SubjectTBox.Location = new Point(77, 12);
            XamlTextBox subject = new XamlTextBox(SubjectTBox);
            subject.SubjectTBox.SpellCheck.IsEnabled = true;
            SubjectTBox.Child = subject;
            this.Controls.Add(SubjectTBox);
        }
    }
