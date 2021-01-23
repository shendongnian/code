        public partial class FormWithTimer : Form
            {
                Timer timer = new Timer();
                public FormWithTimer()
                {
                    InitializeComponent();
        
                    timer.Tick += new EventHandler(timer_Tick); // Everytime timer ticks, timer_Tick will be called
                    timer.Interval = (1000) * (1);              // Timer will tick every second
                    timer.Enabled = true;                       // Enable the timer
                 }
    
    //    .......    
    
               showForm() declaration
               {
               timer.start();
    //    .......
               timer.stop();
               }            
                        
               void timer_Tick(object sender, EventArgs e)
               {
                   //hide form...through visibility
               }
            }
