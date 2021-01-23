     private void OnSquareRootClick(object sender, RoutedEventArgs e)
        {
            double number;
            var isDouble = double.TryParse(this.txtNumber.Text, out number);
            if (isDouble)
            {
                this.txtResult.Text =
                    string.Format(
                        "{0}{1} = {2}", 
                        "\u221A", 
                        this.txtNumber.Text, 
                        Math.Round(Math.Sqrt(number), 2));
            }
        }
