    public partial class Form2 : Form
    {
        public class StatusChangedArgs : EventArgs
        {
            // Put useful information here which would be retrieved from Form1
        }
    
        public event EventHandler<StatusChangedArgs> StatusChanged;
    
        private void OnStatusChanged()
        {
            var handler = StatusChanged;
            if (handler != null)
                handler(this, new StatusChangedArgs());
        }
    
        // Call OnStatusChanged in other Form2's functions, e.g. button click ...
    }
