       int count;
       if (int.TryParse(TextCount.Text, out count))
            {
                count++;
                TextCount.Text = count.ToString();
            }
