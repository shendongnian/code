      private bool _running;
        private BackgroundWorker _bw;
        private Stopwatch _watch;
        public Form1()
        {
            InitializeComponent();
        }
        private void BwOnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            label3.Text = e.UserState.ToString();
        }
        private void BwOnDoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            while (_running)
            {
                if ((worker.CancellationPending == true))
                {
                    e.Cancel = true;
                    return;
                }
                else
                {
                    worker.ReportProgress(0, _watch.Elapsed.Seconds.ToString());
                    // Perform a time consuming operation and report progress.
                    String str1, str2;
                    SqlDataReader rd1, rd2;
                    SqlConnection Con =
                        new SqlConnection(
                            "Data Source=216.218.224.238;Database=chatapp;Uid=chatappuser;pwd=1234@ChatAppUser;MultipleActiveResultSets=true;");
                    // SqlConnection Con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Test;User ID=;Password=;Connection Timeout=600");
                    Con.Open();
                    rd1 =
                        new SqlCommand(
                            "select top 1 Chat from chat where  where email ='" + label4.Text + "'order by id Desc", Con)
                            .ExecuteReader();
                    rd1.Read();
                    str1 = rd1["Chat"].ToString();
                    rd1.Close();
                    rd2 =
                        new SqlCommand(
                            "select top 1 UserInitial from chat where email ='" + label4.Text + "' order by id Desc",
                            Con)
                            .ExecuteReader();
                    rd2.Read();
                    str2 = rd2["UserInitial"].ToString();
                    rd2.Close();
                    if (str1 != str2)
                    {
                        SqlDataReader rd3, rd4;
                        rd3 =
                            new SqlCommand(
                                "select top 1 UserInitial from chat  where email ='" + label4.Text + "'order by id desc",
                                Con).ExecuteReader();
                        var value = rd3.Read();
                        rd3.Close();
                        if (richTextBox1.InvokeRequired)
                        {
                            richTextBox1.BeginInvoke(
                                new MethodInvoker(() => richTextBox1.Text += richTextBox1.Text + " <br /> " + value));
                        }
                        else
                        {
                            richTextBox1.Text = richTextBox1.Text + " <br /> " + value;
                        }
                        rd4 =
                            new SqlCommand(
                                "Update top 1 chat set Chat = UserInitial  where email ='" + label4.Text +
                                "'order by id desc", Con).ExecuteReader();
                        rd4.Read();
                        rd4.Close();
                        Con.Close();
                    }
                    Thread.Sleep(1000); //sleep 1 second
                }
                //System.Threading.Thread.Sleep(500);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            _running = true;
            _watch = new Stopwatch();
            _watch.Start();
            _bw.RunWorkerAsync();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _bw = new BackgroundWorker();
            _bw.WorkerReportsProgress = true;
            _bw.DoWork += BwOnDoWork;
            _bw.ProgressChanged += BwOnProgressChanged;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            _running = false;
            _bw.CancelAsync();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _bw.CancelAsync();
            _bw.Dispose();
            _watch.Stop();
        }
