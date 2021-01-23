    protected void calculatePowerButton_Click(object sender, EventArgs e){
        int numberInt = int.Parse(numberPowerTextBox.Text);
        int powerInt = int.Parse(powerTextBox.Text);
        int resultInt = 1; 
        for(int i=0; i<powerInt; i++){
            resultInt *= numberInt;
        }
        resultTextBox.Text = resultInt.ToString();
    }
