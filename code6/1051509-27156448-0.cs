    private void ConfirmOrder_Click(object sender, EventArgs e)
    {
        string pizzaChoice = "";
        if (NeapolitanStyle.Checked == false & NEGreekStyle.Checked == false & ChicagoStyle.Checked == false & SmallPizza.Checked == false & MediumPizza.Checked == false & LargePizza.Checked == false)
        { 
            MessageBox.Show("Incomplete order. Please review.", "Incomplete Order."); 
        }
        else {
            if (SmallPizza.Checked)
            {
                pizzaChoice = pizzaChoice + SmallPizza.Text + " "; 
            }
            if (MediumPizza.Checked)
            {
                pizzaChoice = pizzaChoice + MediumPizza.Text + " "; 
            }
            if (LargePizza.Checked)
            {
                pizzaChoice = pizzaChoice + LargePizza.Text + " "; 
            }
            if (NEGreekStyle.Checked)
            {
                pizzaChoice = pizzaChoice + NEGreekStyle.Text + " pizza" + "\n";
            }
            if (ChicagoStyle.Checked)
            {
                pizzaChoice = pizzaChoice + ChicagoStyle.Text + " pizza" + "\n";
            }
            if (NeapolitanStyle.Checked)
            {
                pizzaChoice = pizzaChoice + NeapolitanStyle.Text + " pizza" + "\n"; 
            }
            if (VeryHotChilis.Checked)
            {
                pizzaChoice = pizzaChoice + "& " + VeryHotChilis.Text + "." + "\n"; 
            }
            if (Onions.Checked)
            {
                pizzaChoice = pizzaChoice + "& " + Onions.Text + "." + "\n"; 
            }
            if (Mushrooms.Checked)
            {
                pizzaChoice = pizzaChoice + "& " + Mushrooms.Text + "."  + "\n"; 
            }
            MessageBox.Show("You have ordered a " + pizzaChoice, "Order Confirmation.");
        }
    }
