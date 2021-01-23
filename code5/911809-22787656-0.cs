     namespace ThreadSafeTest
     {
     public partial class Form1 : Form
     {
        public Form1()
        { 
            InitializeComponent(); 
            ProgramState.MainForm = this; 
        }
        private void button1_Click(object sender, EventArgs e)
        { 
            Thread t = new Thread(ThreadStartMethod); 
            t.Start(); 
        }
        private void ThreadStartMethod(object obj)
        { 
            Invoke(() => 
            { 
                ProgramState.MainForm.Show(); 
            });
        }
    }
    public static class ProgramState
    { 
        public static Form1 MainForm; 
    }
    }
