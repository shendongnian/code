    complete code for Form1:
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace DownloadAttachmentExchange
    {
    public partial class Form1 : Form
    {
        private string path = "";
        public string subject = "";
        public string attachment = "";
        public string date = "";
        public string sender = "";
        public Form1()
        {
            InitializeComponent();
        }
        ExchangeDwnClass exchange = new ExchangeDwnClass();
        BackgroundWorker bgrWorker = new BackgroundWorker();
        private void button3_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog(this)== DialogResult.OK)
            {
                path = folderBrowserDialog1.SelectedPath;   
                exchange.Path = path;
                pathTxt.Text = path;
            }
        }
        private void onBtn_Click(object sender, EventArgs e)
        {
            exchange.EmailFetch=Convert.ToInt32(fetchUpDown.Value);
            exchange.FilterSender = fromFilterTxt.Text;
            exchange.Exchange = exchangeTxt.Text;
            exchange.Password = passwdTxt.Text;
            exchange.Username = userTxt.Text;
            backgroundWorker1.RunWorkerAsync();
        }
        private void filterExcelCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (filterExcelCheck.CheckState == CheckState.Checked)
            {
                exchange.FilterExcel = ".xlsx";
            }
            else
            {
                exchange.FilterExcel = "";
            }
        }
        private void filterCSVCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (filterCSVCheck.CheckState == CheckState.Checked)
            {
                exchange.FilterCsv = ".csv";
            }
            else
            {
                exchange.FilterCsv = "";
            }
        }
        private void exchangeTxt_MouseHover(object sender, EventArgs e)
        {
            tipLbl.Visible = true;
            tipLbl.Text = "It is usually same as email address...";
        }
        private void exchangeTxt_MouseLeave(object sender, EventArgs e)
        {
            tipLbl.Visible = false;
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //logOutputTxt.Text += "\n" + date + " , Message subject: " + subject + " , Attachment name: " + attachment + "\r"
            //backgroundWorker1.ReportProgress(0);
            exchange.GetAttachments(this);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            logOutputTxt.Text += "\n" + date + " , Sender: "+sender+" , Message subject: " + subject + " , Attachment name: " + attachment + "\r";
        }
    }
    }
