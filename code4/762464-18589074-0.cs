     public partial class Form1 : Form
        {
            List<Task<bool>> taskList = new List<Task<bool>>();
            public Form1()
            {
                InitializeComponent();
            }
    
            private async void button1_Click(object sender, EventArgs e)
            {            
                Task<bool> task = Task.Run(() => SaveDetails());
                MessageBox.Show(task.Id + " started.");
                taskList.Add(task);
                var isSuccess = await task;
            }
            public bool SaveDetails()
            {
                for (int i = 0; i < 10; i++)
                {
                    System.Threading.Thread.Sleep(5000);
                    //MessageBox.Show("Finishing.");                
                }
                return true;
            }       
    
            private void button2_Click(object sender, EventArgs e)
            {            
                foreach (var task in taskList)
                {                
                    if (task.IsCompleted == true)
                        MessageBox.Show(task.Id + " Completed.");
                }        
            }
        }
