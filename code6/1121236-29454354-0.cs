        double firstValue;
        double secondValue;
        double answer;
        if (double.TryParse(txtFirstValue.Text, out firstValue) == false)
        {
            MessageBox.Show("The value(s) entered must be > 0");
        }
        if(double.TryParse(txtSecondValue.Text, out secondValue) == false)
        {
            MessageBox.Show("The value(s) entered must be > 0");
        }
            answer = firstValue + secondValue; 
            lblAnswer.Text = answer.ToString();
    }
