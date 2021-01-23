     public partial class Form1 : Form
         {
        int formCount = 0;
        int X = 10;
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        public Form1()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(timer_Tick); // Everytime timer ticks, timer_Tick will be called
            timer.Interval = (1000) * X;              // Timer will tick evert second
            timer.Enabled = true;                       // Enable the timer
            timer.Start();
            
           
            
        }
      
        void timer_Tick(object sender, EventArgs e)
        {
            FormCollection fc = new FormCollection();
            fc = Application.OpenForms;
       
            foreach (Form Z in fc)
            {
               
                X = X + 5;
                formCount++;
                if (formCount == fc.Count)
                    X = 5;
               
                Z.TopMost = true;
                Z.WindowState = FormWindowState.Normal;
                System.Threading.Thread.Sleep(5000);   
            }
          
          
        }
 
        
    }
