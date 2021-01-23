    private void btnSubtraction_Click(object sender, EventArgs e)
    {
        c = '-';
        num1 = double.Parse(txtBox.Text);
        txtBox.Text += c; <-------Change this line
    }
    private void btnMultiplication_Click(object sender, EventArgs e)
    {
        c = '*';
        num1 = double.Parse(txtBox.Text);
        txtBox.Text += c; <-------Change this line
    }
    private void btnDivision_Click(object sender, EventArgs e)
    {
        c = '/';
        num1 = double.Parse(txtBox.Text);
        txtBox.Text += c; <-------Change this line
    }
