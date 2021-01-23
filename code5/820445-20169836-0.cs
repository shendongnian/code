            numbers[0] = 1;
            numbers[1] = 5;
            numbers[2] = 4;
            numbers[3] = 9;
            numbers[4] = 3;
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    textBox1.AppendText(numbers[i].ToString() + "\n");
                }
                catch (IndexOutOfRangeException)
                {
                    MessageBox.Show("Now you're gone too far.");
                    break;
                }
            }
