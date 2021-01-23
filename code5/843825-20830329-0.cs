    private void btnEquals_Click(object sender, EventArgs e) {
    
    		if (plusButtonClicked == true) {
    			total2 = total1 + double.Parse(txtDisplay.Text);
    		}
    		else if (minusButtonClicked == true) {
    			total2 = total1 - double.Parse(txtDisplay.Text);
    		}
    		else if (multiplyButtonClicked == true) {
    			total2 = total1 * double.Parse(txtDisplay.Text);
    		}
    		else if (divideButtonClicked == true) {
    			total2 = total1 / double.Parse(txtDisplay.Text);
    		}
    
    		txtDisplay.Text = total2.ToString();
    		total1 = 0;
    	}
