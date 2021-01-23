    public partial class Form1 : Form
    {
        const string XML_FILE_NAME = "D:\\emps.txt";
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            prepareDataGrid();
            List<JOBS> jobsList = prepareXML(XML_FILE_NAME);
            for (int i = 0; i < jobsList.Count; i++)
            {
                addDateRow(jobsList[i].jobDate.ToString("M'/'d'/'yyyy"));
                for (int j = 0; j < jobsList[i].jobDetailsList.Count; j++)
                    dgv.Rows.Add(new string[] { 
                        jobsList[i].jobDetailsList[j].JobNumber,
                        jobsList[i].jobDetailsList[j].JobHours
                    });
            }
        }
        DataGridView dgv;
        void prepareDataGrid()
        {
            dgv = new DataGridView();
            dgv.BackgroundColor = Color.White;
            dgv.GridColor = Color.White;
            dgv.DefaultCellStyle.SelectionBackColor = Color.White;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Width = 600;
            dgv.Dock = DockStyle.Left;
            this.BackColor = Color.White;
            dgv.Columns.Add("Col1", "Col1");
            dgv.Columns.Add("Col2", "Col2");
            dgv.Columns[0].Width = 110;
            dgv.Columns[1].Width = 40;
            dgv.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);
            dgv.RowHeadersVisible = dgv.ColumnHeadersVisible = false;
            dgv.AllowUserToAddRows =
            dgv.AllowUserToDeleteRows =
            dgv.AllowUserToOrderColumns =
            dgv.AllowUserToResizeColumns =
            dgv.AllowUserToResizeRows =
            !(dgv.ReadOnly = true);
            Controls.Add(dgv);
        }
        void addJobRow(string jobNum, string jobHours)
        {
            dgv.Rows.Add(new string[] {jobNum, jobHours });
        }
        void addDateRow(string date)
        {
            dgv.Rows.Add(new string[] { date, ""});
            dgv.Rows[dgv.Rows.Count - 1].DefaultCellStyle.SelectionForeColor =
            dgv.Rows[dgv.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Firebrick;
            dgv.Rows[dgv.Rows.Count - 1].DefaultCellStyle.Font = new Font("Segoe UI Light", 13.5F);
            dgv.Rows[dgv.Rows.Count - 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Rows[dgv.Rows.Count - 1].Height = 25;
        }
        List<JOBS> prepareXML(string fileName)
        {
            string xmlContent = "";
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            using (StreamReader sr = new StreamReader(fs)) xmlContent = sr.ReadToEnd();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlContent);
            List<JOBS> jobsList = new List<JOBS>();
            XmlNode form1Node = doc.ChildNodes[1];
            for (int i = 0; i < form1Node.ChildNodes.Count; i++)
            {
                XmlNode dateNode = form1Node.ChildNodes[i].ChildNodes[0].ChildNodes[0],
                    jobNumNode = form1Node.ChildNodes[i].ChildNodes[1].ChildNodes[0],
                    timeTicksNode = form1Node.ChildNodes[i].ChildNodes[6].ChildNodes[0];
                bool foundDate = false;
                for (int j = 0; j < jobsList.Count; j++) if (jobsList[j].compareDate(dateNode.Value))
                    {
                        jobsList[j].addJob(jobNumNode.Value, Math.Round(TimeSpan.FromTicks(
                            (long)Convert.ToDouble(timeTicksNode.Value)).TotalHours, 2).ToString());
                        foundDate = true;
                        break;
                    }
                if (!foundDate)
                {
                    JOBS job = new JOBS(dateNode.Value);
                    string jbnum = jobNumNode.Value;
                    string tbtck = timeTicksNode.Value;
                    long tktk = Convert.ToInt64(tbtck);
                    double tkdb = TimeSpan.FromTicks(tktk).TotalHours;
                    job.addJob(jobNumNode.Value, Math.Round(TimeSpan.FromTicks(
                            Convert.ToInt64(timeTicksNode.Value)).TotalHours, 2).ToString());
                    jobsList.Add(job);
                }
            }
            jobsList.OrderByDescending(x => x.jobDate);
            return jobsList;
        }
        class JOBS
        {
            public DateTime jobDate;
            public List<JobDetails> jobDetailsList = new List<JobDetails>();
            public void addJob(string jobNumber, string jobHours)
            {
                jobDetailsList.Add(new JobDetails() { JobHours = jobHours, JobNumber = jobNumber });
            }
            public JOBS(string dateString)
            {
                jobDate = getDateFromString(dateString);
            }
            public JOBS() { }
            public bool compareDate(string dateString)
            {
                return getDateFromString(dateString) == jobDate;
            }
            private DateTime getDateFromString(string dateString)
            {
                string[] vals = dateString.Split('/');
                return new DateTime(Convert.ToInt32(vals[2]), Convert.ToInt32(vals[0]), Convert.ToInt32(vals[1]));
            }
        }
        class JobDetails
        {
            public string JobNumber { get; set; }
            public string JobHours { get; set; }
        }
    }
