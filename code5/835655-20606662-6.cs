    public partial class Form1 : Form
    {
        public event Action<int> NumberCalculated;
        private void ButtonClick(object sender, EventArgs e)
        {            
            int value = 42; // calculate value
            if (NumberCalculated != null)
                NumberCalculaed(value);
        }
    }
