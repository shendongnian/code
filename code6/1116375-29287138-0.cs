    public partial class AddingClient : Form //(Form 2)
    {
        private Form1 UseForm1; // The Object to access Form1's listview
        public AddingClient()
        {            
            InitializeComponent();
        }
        public void setForm1(Form1 form)
        {
            UseForm1 = form;
        }
        public void Accept_Click(object sender, EventArgs e) // When all textbox's are filled press accept to add to listview.
        {
            try
            {
                // Check to see if there are any blank texts, we can't be having those.
                if (name.Text == string.Empty)
                    throw new System.ArgumentException("You must fill all blanks.", "Name");
                if (phoneN.Text == string.Empty)
                    throw new System.ArgumentException("You must fill all blanks.", "Phone Number");
                if (address.Text == string.Empty)
                    throw new System.ArgumentException("You must fill all blanks.", "Address");
                if (email.Text == string.Empty)
                    throw new System.ArgumentException("You must fill all blanks.", "Email");
                // Use the info given via textbox's and add them to items/subitems
                ListViewItem lvi = new ListViewItem(name.Text);
                lvi.SubItems.Add(phoneN.Text);
                lvi.SubItems.Add(address.Text);
                lvi.SubItems.Add(email.Text);
                // Add the items to the list view.
                UseForm1.listView1.Items.Add(lvi); // This is the code I believe to be the problem but found no solutions.
                // If no error, success.
                MessageBox.Show("Successfully Added Client", "Success");
                Close();
            }
            catch(Exception ex)
            {
                //If error show the error
                MessageBox.Show(ex.Message,"Error");
            }
        }
    }
