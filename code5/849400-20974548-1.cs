    public class MyClass : Form
    
        public float HalfDay = 0.0f;
        
        protected void cmbStartDate_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbStartDate.SelectedIndex == 0)
            {
                HalfDay = HalfDay + 0.5;
            }
        
           lblNumberOfDays.Text = HalfDay.ToString();
        }
        
        protected void cmbEndDate_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbEndDate.SelectedIndex == 0)
            {
                HalfDay = HalfDay - 0.5;
            }
        
           lblNumberOfDays.Text = HalfDay.ToString();
        }
    }
