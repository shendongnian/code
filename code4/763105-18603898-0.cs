    // is the current txtBox value new, so will be cleared and allow op change
    private bool isNew = true;
    // change this to default to +
    string c = "+";
    double num1 = 0;
    private void Evaluate(string newOperand)
    {
        if (isNew)
        {
            // just update the operand, don't perform an evaluate
            c = newOperand;
            return;
        }
        double num2 = double.Parse(txtBox.Text);
        switch (c)
        {
            case "+":
                num1 = num1 + num2;
                break;
            // etc for -, /, *
            // for "="
            default:
                num1 = num1 + num2;
                break;
        }
        isNew = true;
        c = newOperand;
    }
    // this can be assigned as the handler for buttons 0 - 9
    public void btnNumber_Click(object sender, EventArgs e)
    {
        var button = sender as Button;
        txtBox.Text += button.Text;
        isNew = false;
    }
    // this can be assigned as the event handler for all operations: +, -, /, *, =
    public void btnOperation_Click(object sender, EventArgs e)
    {
        var button = sender as Button;
        Evaluate(button.Text);
    }
