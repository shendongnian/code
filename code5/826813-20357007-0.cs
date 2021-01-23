    // do the math
    var subtotal = double.Parse(txtMoney.Text) + fivepence.cash1();
    // update the user interface
    txtMoney.Text = subtotal.ToString();
    // update total1, whatever that is
    total1 += subtotal;
