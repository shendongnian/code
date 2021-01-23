    private void btnOperator_Click(object sender, EventArgs e)
    {
        checkForEmptySpace();
        double num1, num2, sum;
        num1 = double.Parse(txtNum1.Text);
        num2 = double.Parse(txtNum2.Text);
          
        double result = 0;
        switch((sender as Button).Name)
        {
           case "btnSubtract":
              result = num1 - num2;
              break;
           case "btnAdd":
              //...
        }  
  
        txtAnswer.Text = Convert.ToString(sum);
    }
