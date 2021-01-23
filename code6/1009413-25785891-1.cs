    private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            tb.Text += b.Content.ToString();
        }
     private void Result_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    result();
                }
                catch (Exception exc)
                {
                    Console.WriteLine("Receiving", exc.StackTrace);
                    tb.Text = "Error!";
                }
            }
    private void result()
            {
                String op;
                int iOp = 0;
                if (tb.Text.Contains("+"))
                {
                    iOp = tb.Text.IndexOf("+");
                }
                else if (tb.Text.Contains("-"))
                {
                    iOp = tb.Text.IndexOf("-");
                }
                else if (tb.Text.Contains("*"))
                {
                    iOp = tb.Text.IndexOf("*");
                }
                else if (tb.Text.Contains("/"))
                {
                    iOp = tb.Text.IndexOf("/");
                }
                else
                {
                    tb.Text = "Error";
                }
    
                op = tb.Text.Substring(iOp, 1);
                double op1 = Convert.ToDouble(tb.Text.Substring(0, iOp));
                double op2 = Convert.ToDouble(tb.Text.Substring(iOp + 1, tb.Text.Length - iOp - 1));
    
                if (op == "+")
                {
                    tb.Text += "=" + (op1 + op2);
                }
                else if (op == "-")
                {
                    tb.Text += "=" + (op1 - op2);
                }
                else if (op == "*")
                {
                    tb.Text += "=" + (op1 * op2);
                }
                else
                {
                    tb.Text += "=" + (op1 / op2);
                }
            }
