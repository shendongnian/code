    public partial class frmTestGirdBinding : Form
    {
        CustomDataCollection cdata = new CustomDataCollection();
        Random rnd = new Random();
        public frmTestGirdBinding()
        {
            InitializeComponent();
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
        }
        private void frmTestGirdBinding_Load(object sender, EventArgs e)
        {
            BindingSource bindingSource1 = new BindingSource();
            bindingSource1.DataSource = cdata;
            dataGridView1.DataSource = bindingSource1;            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cdata.Count; i++)
            {
                cdata[i].Reading = (float)rnd.NextDouble();
            }
            dataGridView1.Refresh(); //without this all rows are not updating
        }
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //InVisible the rows
            dataGridView1.Rows[2].Visible = false;
            dataGridView1.Rows[3].Visible = false;
        }
    }
    class CustomDataCollection : BindingList<CustomData>
    {
        public CustomDataCollection()
        {
            this.Add(new CustomData() { SrNo = 1, Name = "A", Reading = 11.11F });
            this.Add(new CustomData() { SrNo = 2, Name = "B", Reading = 22.11F });
            this.Add(new CustomData() { SrNo = 3, Name = "C", Reading = 33.11F });
            this.Add(new CustomData() { SrNo = 4, Name = "D", Reading = 44.11F });
            this.Add(new CustomData() { SrNo = 5, Name = "E", Reading = 55.11F });
            this.Add(new CustomData() { SrNo = 6, Name = "F", Reading = 66.11F });
            this.Add(new CustomData() { SrNo = 7, Name = "G", Reading = 77.11F });
        }
    }
    class CustomData : INotifyPropertyChanged
    {
        int srno;
        public int SrNo
        {
            get { return srno; }
            set { srno = value; OnPropertyChanged("SrNo"); }
        }
        string name;
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }
        float reading;
        public float Reading
        {
            get { return reading; }
            set { reading = value; OnPropertyChanged("Reading"); }
        }
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
