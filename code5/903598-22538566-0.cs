    public partial class Form1 : Form
    {
        private List<String> listData;
        public Form1()
        {
            this.listData = new List<String>();
            InitializeComponent();
        }
        private void checkBoxs_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox theCheckBoxChanged = sender as CheckBox;
            // verify the event is from a checkbox
            if (theCheckBoxChanged != null)
            {
                if (theCheckBoxChanged.Checked)
                {
                    // add data
                    this.listData.Add(theCheckBoxChanged.Text);
                }
                else
                {
                    // remove data
                    this.listData.Remove(theCheckBoxChanged.Text);
                }
                this.UpdateTextBox();
            }
        }
        private void UpdateTextBox()
        {
            // be carefull, you can't concatenate if there is no data.
            if (this.listData.Count > 0)
            {
                // sort and concatenate
                this.textBox1.Text = this.listData
                                         .OrderBy(s => s)
                                         .Aggregate((s1, s2) => s1 + " and " + s2);
            }
            else
            {
                this.textBox1.Text = String.Empty;
            }
        }
    }
