    private double CalculateTotal()
    {
        var price = 0.0;
        if (smallPizza.Checked)
            price += 9.0;
        if (mediumPizza.Checked)
            price += 12.0;
        if (mediumPizza.Checked)
            price += 14.0;
        if (pineapple.Checked)
            price += 0.5;
        if (margeritta.Checked)
            price += 1.0;
        if (pepperoni.Checked)
            price += 12.0;
        if (hawaiian.Checked)
            price += 3.0;
        if (salami.Checked)
            price += 0.5;
        if (goatsCheese.Checked)
            price += 0.5;
        if (chorizo.Checked)
            price += 0.5;
        return price;
    }
