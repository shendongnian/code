    private TextBox txtNumerator, txtDenominator, txtResult;
    public MyClass() {
      txtNumerator = new TextBox();
      txtNumerator.TextChanged += new TextChangedEvent(TextBox_TextChanged);
      txtDenominator = new TextBox();
      txtResult = new TextBox();
    }
    private void TextBox_TextChanged(object sender, EventArgs e) {
      double numerator = Convert.ToDouble(txtNumerator.Text.Trim());
      double denominator = Convert.ToDouble(txtDemominator.Text.Trim());
      if (denominator != 0) {
        double result = numerator / denominator;
        // Ref: http://www.csharp-examples.net/string-format-double/
        txtResult.Text = string.Format("{0:0.00}", result);
      } else {
        throw new DivideByZeroException("Denominator can not be zero.");
      }
    }
