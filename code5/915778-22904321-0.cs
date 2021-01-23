    int tot = 0;
    int sum = 0;   
    int price = 0;                           // output parameter to receive value
    int quantity = 0;                        // output parameter to receive value
    int total = 0;                           // output parameter to receive value
    TryParse(unitprice.Text, out price);     // price contains the unit price value
    TryParse(quantitytxt.Text out quantity); // quantity contains the quantity value
    TryParse(total.Text, out total);         // total contains the total value
    tot = price * quantity;
    sum = total + tot;
    total.Text = sum.ToString();
