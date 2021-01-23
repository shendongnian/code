     private CalculationEngine engine = new CalculationEngine();
     private void ExecuteButton_Click(object sender, RoutedEventArgs e)
     {
        double result = engine.Calculate(ExpressionTextBox.Text);
        ExpressionTextBox.Text = result.ToString();  // displays the result
     }
