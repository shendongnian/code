    double sumMoney = 0;
    foreach (ListItem li in listBox1.Items)
    {
         sumMoney = sumMoney + Convert.ToDouble(li.Value);
    }
    lblText.Text = sumMoney.ToString()
