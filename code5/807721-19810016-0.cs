    private void btend_Click(object sender, RoutedEventArgs e)
    {
        try{
            tala1 = Convert.ToInt32(tbtala1.Text);
            tala2 = Convert.ToInt32(tbtala2.Text);
            svar = Convert.ToInt32(tbsvar.Text);
            if (svar == (tala1 * tala2))
            {
                MessageBox.Show("Rétt!");
            }
            else
            {
                MessageBox.Show("Rangt... :(");
            }
        }catch{
            MessageBox.Show("Invalid input");
        }
    }
