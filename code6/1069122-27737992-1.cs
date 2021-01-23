    private double value1;
    private double value2;
    private double value3;
    private double value4;
    
    private void groupBox1_Enter(object sender, EventArgs e)
    {
    	if (radioButton1.Checked)
    		value1 = 0.9;
    	else if (radioButton2.Checked)
    		value1 = 0.8;
    	else if (radioButton3.Checked)
    		value1 = 0.7;
    	else if (radioButton4.Checked)
    		value1 = 0.3;
    	else if (radioButton5.Checked)
    		value1 = 0.5;
    	else
    		MessageBox.Show("Oda Tipi girilmedi.");
    }
    
    private void groupBox2_Enter(object sender, EventArgs e)
    {
    	if (radioButton6.Checked)
    		value2 = 1;
    	else if (radioButton7.Checked)
    		value2 = 0.8;
    	else if (radioButton8.Checked)
    		value2 = 0.6;
    	else
    		MessageBox.Show("İzolasyon Tipi girilmedi.");
    }
    
    private void groupBox3_Enter(object sender, EventArgs e)
    {
    	if (radioButton9.Checked)
    		value3 = 0.9;
    	else if (radioButton10.Checked)
    		value3 = 1;
    	else
    		MessageBox.Show("Cam Tipi girilmedi.");
    
    }
    
    private void groupBox4_Enter(object sender, EventArgs e)
    {
    	if (radioButton11.Checked)
    		value4 = 1;
    	else if (radioButton12.Checked)
    		value4 = 0.9;
    	else
    		MessageBox.Show("Formül katsayısı girilmedi.");
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
    	textBox5.Text = Convert.ToString(
    	value1 
    	* value2 
    	* value3 
    	* value4 
    	* (Convert.ToDouble(textBox2.Text)) 
    	* (Convert.ToDouble(textBox3.Text)) 
    	* (Convert.ToDouble(textBox4.Text)));
    
    }
