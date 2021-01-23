    private void radioButton1_CheckedChanged(object sender, EventArgs e)
    {
        const double SmallPizzaPrice = 9.0;
        if (smallPizza.Checked)
        {            
            this.pizzaTotal += SmallPizzaPrice;
        }
        else
        {
            this.pizzaTotal -= SmallPizzaPrice;
        }
    }
