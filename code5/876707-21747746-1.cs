    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsForms_21739538
    {
        public partial class MainForm : Form
        {
            public MainForm()
            {
                InitializeComponent();
    
                // test the btnSubmit_Click
                this.Load += async (s, e) =>
                {
                    await Task.Delay(2000);
                    btnSubmit_Click(this, EventArgs.Empty);
                };
            }
    
            private async void btnSubmit_Click(object sender, EventArgs e)
            {
                try
                {
                    // show the "wait" dialog asynchronously
                    var dialog = await DisplayCustomMessageBox("Please Wait");
    
                    // do the work on a pool thread
                    await Task.Run(() =>
                        ProcessRequest());
                    // close the dialog    
                    dialog.Item1.Close();
                    // make sure the dialog has shut down
                    await dialog.Item2;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
    
            // show a modal dialog asynchrnously
            private async Task<Tuple<Form, Task<DialogResult>>> DisplayCustomMessageBox(string title)
            {
                //CustomMessageBox = new frm_Message { Text = title };
                var CustomMessageBox = new Form();
    
                CustomMessageBox.Text = "Please wait ";
    
                var tcs = new TaskCompletionSource<bool>();
    
                CustomMessageBox.Load += (s, e) =>
                    tcs.TrySetResult(true);
    
                var dialogTask = Task.Factory.StartNew(
                    ()=> CustomMessageBox.ShowDialog(),
                    CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskScheduler.FromCurrentSynchronizationContext());
    
                // await the dialog initialization
                await tcs.Task;
    
                return Tuple.Create(CustomMessageBox, dialogTask);
            }
    
            void ProcessRequest()
            {
                // simulate some work
                Thread.Sleep(2000);
            }
        }
    }
