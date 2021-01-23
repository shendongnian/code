    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Threading;
    namespace UpdatePanel
    {
        public partial class Default : System.Web.UI.Page
        {
            protected static string content;
            protected static bool inProcess = false;
            protected static bool processComplete = false;
            protected static string processCompleteMsg = "Finished Processing All Records.";
            protected void Page_Load(object sender, EventArgs e){ }
            protected void Button1_Click(object sender, EventArgs e)
            {
                Button1.Enabled = false;
                Timer1.Enabled = true;
                Thread workerThread = new Thread(new ThreadStart(ProcessRecords));
                workerThread.Start();
            }
            protected void ProcessRecords()
            {
                inProcess = true;
                for (int x = 1; x <= 5; x++)
                {
                    content += "Beginning Processing Step " + x.ToString() + " at " + DateTime.Now.ToLongTimeString() + "..." + System.Environment.NewLine;
                    Thread.Sleep(1000);
                    content += "Completed Processing Step " + x.ToString() + " at " + DateTime.Now.ToLongTimeString() + System.Environment.NewLine + System.Environment.NewLine;
                }
                processComplete = true;
                content += processCompleteMsg;
            }
            protected void Timer1_Tick(object sender, EventArgs e)
            {
                if (inProcess)
                    TextBox1.Text = content;
                int msgLen = processCompleteMsg.Length;
                if (processComplete && TextBox1.Text.Substring(TextBox1.Text.Length - processCompleteMsg.Length) == processCompleteMsg) //has final message been set?
                {
                    inProcess = false;
                    Timer1.Enabled = false;
                    Button1.Enabled = true;
                }
            }
        
        }
    }
