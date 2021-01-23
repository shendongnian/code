    public class ParentForm : Form
    {
        Button openButton = new Button();
        public ParentForm()
        {
            openButton.Click += openButton_Click;
        }
        void openButton_Click(object sender, EventArgs e)
        {
            ChildForm childForm = new ChildForm();
            childForm.OKButtonClick += childForm_OKButtonClick;
            childForm.ShowDialog();
        }
        void childForm_OKButtonClick(object sender, MyEventArgs e)
        {
            // Use properties from event args and set data in this form
        }
    }
    public class ChildForm : Form
    {
        Button okButton = new Button();
        TextBox name = new TextBox();
        TextBox address = new TextBox();
        public event EventHandler<MyEventArgs> OKButtonClick;
        public ChildForm()
        {
            okButton.Click += okButton_Click;
        }
        void okButton_Click(object sender, EventArgs e)
        {
            if (OKButtonClick != null)
            {
                MyEventArgs myEventArgs = new MyEventArgs();
                myEventArgs.Name = name.Text;
                myEventArgs.Address = address.Text;
                OKButtonClick(sender, myEventArgs);
            }
        }
    }
    public class MyEventArgs : EventArgs
    {
        public string Name
        {
            get;
            set;
        }
        public string Address
        {
            get;
            set;
        }
    }
