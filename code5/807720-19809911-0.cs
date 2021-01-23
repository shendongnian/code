    private void bt_end_Click(object sender, RoutedEventArgs e)
    {
        int number1 = 0;
        int number2 = 0;
        if (int.TryParse(tbnumber1.Text, out number1) || 
            int.TryParse(tbnumber12.Text, out number2)) MessageBox.Show("Rangt...");
        MessageBox.Show(svar == number1 * number2 ? "Rétt!" : "Rangt...");
    }
