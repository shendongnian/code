    // Store values for each RadioButton in a dictionary.
    private Dictionary<RadioButton, double> values = 
        new Dictionary<RadioButton, double>();
    private Dictionary<GroupBox, string> messages = 
        new Dictionary<GroupBox, string>();
    
    public Form1()
    {
          InitializeComponent();
          // Associate values with radio buttons.
          values[radioButton1] = 0.9;
          // repeat the same for others...
          // Associate values messages with group boxes.
          messages[groupBox1] = "Oda Tipi girilmedi.";
          // repeat the same for others...
    }
    
    #region GroupBox.Enter event handlers.
    private void groupBox1_Enter(object sender, EventArgs e)
    {
        RadioButton radioButton = GetSelectedRadioButton(sender as GroupBox);
        if (radioButton == null)
        {
            MessageBox.Show(messages[sender as GroupBox]);
        }
    }
    // Here you can either repeat the same for other group boxes 
    // or simply assign this event hander to all of them. 
    // It will get the right message for each group.
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
            MessageBox.Show(message[groupBox1]);
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
