    public partial class machinename : Form
    {
        public machinename()
        {
            InitializeComponent();
        }
        private void buttonAceitarnome_Click(object sender, EventArgs e) //This one can be private
        {
            if (textBoxnomenova.TextLength == 0)
            {
                //Something here
            }
            else
            {
                obj.text = textBoxnomenova.Text; //Initializing the public static variable                
                this.Close(); //Closes the form, next step will be to run the method in obj.cs
            }
        }
    }
