    private void Button_Click(object sender, RoutedEventArgs e)
        {
            float percentage = 0;
            float mistakes = 0;
            string input = TextBox1.Text;
            string letter = TextBox2.Text;
            char[] letters1 = letter.ToCharArray();
            char[] input1 = input.ToCharArray();
            for (int j = 0; j < input1.Length; j++)
            {
                if (input1[j] != letters1[j])
                {
                    mistakes++; 
                }
            }
            percentage = 100 - ((mistakes / letters1.Length) * 100);
            Label2.Content = percentage.ToString();
        }
