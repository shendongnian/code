      //adds together any other charges from partsLaborGroupBox this is an output method
        private void OtherCharges(TextBox partsTextBox,TextBox laborTextBox, out decimal laborCost, out decimal partsCost)
        {
            laborCost = 0m;
            partsCost = 0m;
    
    
            //this chain goes through the partsLaborTextBox and checks to see if there is input, if so it gets the input 
            //if input is not valid it will display a message. 
            if (!string.IsNullOrEmpty(partsTextBox.Text))
            {
                if(decimal.TryParse(partsTextBox.Text, out partsCost))
                {
                    //do nothing
                }
                else
                {
                    MessageBox.Show("Invalid input for parts");
                }
            }
            if (!string.IsNullOrEmpty(laborTextBox.Text))
            {
                if(decimal.TryParse(laborTextBox.Text, out laborCost))
                {
                    //dont need to do anything. 
                }
                else
                {
                    MessageBox.Show("Invalid input for labor");
                }
            }
    
        }
