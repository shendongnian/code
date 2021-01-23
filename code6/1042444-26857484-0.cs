    using System.Collections.Generic;
    public partial class Form1 : Form
    {
        // Change to a list instead of a two-dimensional array
        public IList<string[]> myTable = new List<string[]>();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            OpenFileDialog filediag = new OpenFileDialog();
            filediag.Filter = "CSV files (.csv)|*.csv";
            filediag.Multiselect = false;
            filediag.ShowDialog();
            if (filediag.FileName != null)
            {
                using (var fs = new FileStream(filediag.FileName, FileMode.Open))
                {
                    using (var sr = new StreamReader(fs))
                    {
                        string line1;
                        // myTable has been initialised so no need for initializer here.
                        while ((line1 = sr.ReadLine()/*.Split(',')*/) != null)
                        {
                            var line = line1.Split(',');
                            myTable.Add(line);
                        }
                        catLabel.Show();
                        catLabel.Text = myTable[0][0];
                    }
                }
            }
        }
    }
