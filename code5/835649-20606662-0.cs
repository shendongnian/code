    public partial class Form1 : Form
    {
        public event EventHandler<NumberCalculatedEventArgts> NumberCalculated;
        private void ButtonClick(object sender, EventArgs e)
        {            
            int value = 42; // calculate value
            OnNumberCalculated(value); // Notify subscribers
        }
    
        protected void OnNumerCalculated(int value)
        {
            if (NumberCalculated != null) // Check if somebody needs notification
               NumberCalculated(this, new NumberCalculatedEventArgs(value));
        }
    }
