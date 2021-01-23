    public partial class CalculateDuration : Form
    {
        public CalculateDuration()
        {
            InitializeComponent();
        }
        //Computes the duration in days
        private void Duration()
        {
            if (this.dateTimePicker1.Value.Day > this.dateTimePicker2.Value.Day)
            {
                if (this.dateTimePicker1.Value.Month == this.dateTimePicker2.Value.Month)
                {
                    this.durationTextBox.Text = (-(this.dateTimePicker1.Value.Day - this.dateTimePicker2.Value.Day)).ToString();
                }
                else
                {
                    this.durationTextBox.Text = (this.dateTimePicker1.Value.Day - this.dateTimePicker2.Value.Day).ToString();
                }
                
            }
            else
            {
                this.durationTextBox.Text = (this.dateTimePicker2.Value.Day - this.dateTimePicker1.Value.Day).ToString();
            }
        }
        //This events is triger when the value of datetimepicker is changed
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Duration();
        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            Duration();
        }
    }
