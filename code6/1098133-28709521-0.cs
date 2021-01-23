        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            var pay = 0.00;
            var add = 0.00;
            var age = int.Parse(txtAge.Text);
            var month = txtMonth.Text;
            if (age >= 18 && age <= 55)
            {
                pay = 350;
            }
            else if (age <= 18)
            {
                pay = 150;
            }
            else if (age > 55)
            {
                pay = 35;
            }
            switch (month.ToLower())
            {
                case "january":
                case "july":
                    add = 100;
                    break;
                case "february":
                case "august":
                case "june":
                case "december":
                    add = 120;
                    break;
                case "march":
                case "september":
                    add = 140;
                    break;
                case "april":
                case "october":
                    add = 160;
                    break;
                case "may":
                case "november":
                    add = 180;
                    break;
            }
            lblTotal.Text = Convert.ToString((pay + add) * 1.13); //calculation that prints to the label
        }
