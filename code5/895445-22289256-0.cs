    private void buttonStart_Click(object sender, RoutedEventArgs e)
    {
        string value = textBox3.Text;
        int intval = int.Parse(value);
        Random steps = new Random();
        int n = steps.Next(10, 20);
        if (intval == number)
        { 
            textBox3.Text = "";
            Random rnd = new Random();
            number = rnd.Next(1000, 9999);
            mata.Text = number.ToString();
            n--;
            tick = 60;
            min = 1;
        }
        else
            mata.Text = mata.Text + " " + "NO";
        if (n == 0)
            NavigationService.GoBack();
    }
