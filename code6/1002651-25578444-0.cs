    public class MyFrom : Form {
        private Timer timer = new Timer();
    
        public MyForm() {
            timer.Interval = 3000; // The interval is in ms
            timer.Tick += new TimerTick;
            timer.Start();
        }
        
        private void TimerTick(object sender, EventArgs e) {
            // Get the value from your text boxes here.
        }
    }
