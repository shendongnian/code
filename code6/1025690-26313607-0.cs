    private void button1_Click(object sender, EventArgs e)
    {
    	int x,
    		y;
    
    	x = Convert.ToInt16(textBox1.Text);
    	y = Convert.ToInt16(textBox2.Text);
    
    	if (radioButton1.IsChecked)    //removed `;`, it refers to the empty if block and 'IsChecked' is a property not 'Checked'
    		txtboxResult.Text = Math.Pow(x,y).ToString();    //assign result to a textbox or may be a variable
    
    	if (radioButton2.IsChecked)    //removed `;`
    		(x / y);
    
    	if (radioButton3.IsChecked) ; 
    }
