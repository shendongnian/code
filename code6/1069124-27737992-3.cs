    // Store values for each RadioButton in a dictionary.
    private Dictionary<RadioButton, double> values = 
        new Dictionary<RadioButton, double>();
    
    public Form1()
    {
          InitializeComponent();
          // Associate values with radio buttons.
          values[radioButton1] = 0.9;
          // repeat it for others...
    }
    
    #region GroupBox.Enter event handlers.
    private void groupBox1_Enter(object sender, EventArgs e)
    {
        RadioButton radioButton = GetSelectedRadioButton(sender as GroupBox);
        if (radioButton == null)
        {
            MessageBox.Show("Oda Tipi girilmedi.");
        }
    }
    // ... repeat the same for other group boxes.
    #endregion
    // Gets the selected radio button from the specified group.
    private void RadioButton GetSelectedRadioButton(GroupBox groupBox)
    {
        RadioButton radioButton = 
            groupBox
            .Controls
            .OfType<RadioButton>()
            .Where(rb => rb.Checked)
            .FirstOrDefault();
        return radioButton;
    }
    // Gets selected value from the specified group.
    private double GetSelectedValue(GroupBox groupBox)
    {
        RadioButton radioButton = GetSelectedRadioButton(groupBox);
        if (radioButton == null)
        {
            // Nothing selected yet.
            return double.NaN;
        }
        else
        {
            // Get the value from the dictinary.
            return values[radioButton];
        }
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        // Get the selected values.
        double value1 = GetSelectedValue(groupBox1);
        double value2 = GetSelectedValue(groupBox2);
        double value3 = GetSelectedValue(groupBox3);
        double value4 = GetSelectedValue(groupBox4);
        // Check other values in the same way.
        if (double.IsNaN(value1))
        {
            // show error message
        }
    	textBox5.Text = Convert.ToString(
    	value1 
    	* value2 
    	* value3 
    	* value4 
    	* (Convert.ToDouble(textBox2.Text)) 
    	* (Convert.ToDouble(textBox3.Text)) 
    	* (Convert.ToDouble(textBox4.Text)));
    
    }
