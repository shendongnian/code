    private void bt_end_Click(object sender, RoutedEventArgs e)
    {
        int number1 = 0;
        int number2 = 0;
        number1 = int.Parse(tbnumber1.Text);
        number2 = int.Parse(tbnumber2.Text);
        if (svar == (number1 * number2))
        {
            MessageBox.Show("Rétt!");
        }
        else
        {
            MessageBox.Show("Rangt...");
        }
    }
