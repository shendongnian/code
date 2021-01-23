    public partial class Form1 : Form
    {
        private HelperForm helperForm;
        private Thread processRunner;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (processRunner == null || processRunner.ThreadState == ThreadState.Stopped)
            {
                helperForm = new HelperForm();
                helperForm.Show();
                processRunner = new Thread(new ThreadStart(runProcesses));
                processRunner.Start();
            }
        }
        private void runProcesses()
        {
            this.Invoke(new Action( () => { helperForm.richTextBox1.AppendText("Program started"); }));
            //represents  process1
            Thread.Sleep(2000);
            this.Invoke(new Action( () => { helperForm.richTextBox1.AppendText("Program start to check process1"); }));
            //represents process2  
            Thread.Sleep(2000);
            this.Invoke(new Action( () => { helperForm.richTextBox1.AppendText("Program start to check process2"); }));
            //represents process3  
            Thread.Sleep(2000);
            this.Invoke(new Action(() => { helperForm.richTextBox1.AppendText("Program start to check process3"); }));
            //represents process4  
            Thread.Sleep(2000);
            this.Invoke(new Action(() => { helperForm.richTextBox1.AppendText("All the process are done!"); }));
            // to let the message display
            Thread.Sleep(2000);
            helperForm.Invoke(new Action(() => { helperForm.Close(); }));
        }
    }
