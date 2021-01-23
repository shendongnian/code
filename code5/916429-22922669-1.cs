    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication4
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private IEnumerable<string> _source = new List<string>() { "one", "two", "three", "four", "five" };
            public void doWork()
            {
                CancellationTokenSource _tokenSource = new CancellationTokenSource();
                var token = _tokenSource.Token;
                Task.Factory.StartNew(() =>
                {
                    try
                    {
                        Parallel.ForEach(_source,
                            new ParallelOptions
                            {
                                MaxDegreeOfParallelism = 4 //limit number of parallel threads 
                            },
                            file =>
                            {
                                if (token.IsCancellationRequested)
                                    return;
                                if (InvokeRequired)
                                {
                                    Invoke((Action<string>)richTextBox1.AppendText, "Task no: " + Task.CurrentId + " processing file: " + file + Environment.NewLine);
                                }
                                else
                                {
                                    richTextBox1.AppendText("Task no: " + Task.CurrentId + " processing file: " + file + Environment.NewLine);
                                }
                            });
                    }
                    catch (Exception)
                    { }
    
                }, _tokenSource.Token).ContinueWith(
                        t =>
                        {
                            //finish...
                        }
                    , TaskScheduler.FromCurrentSynchronizationContext() //to ContinueWith (update UI) from UI thread
                    );
            }
            private void button1_Click(object sender, EventArgs e)
            {
                doWork();
            }
        }
    }
