        private void Button_Click(object sender, RoutedEventArgs e)
        {
            char[] charArray = new char[] { 'a', 'e', 'i', 'o', 'u' };
            string line = testBox.Text.ToLower();
            char letter;
            List<char> vowels = 0;
            List<char> sug = 0;
            for (int i = 0; i < line.Length; i++)
            {
                letter = line[i];
                if (charArray.Contains(letter))
                    vowels.Add(letter);
                if (!charArray.Contains(letter))
                    sug.Add(letter);
            }
            MessageBox.Show("number of vowels is" + vowels.Count);
            MessageBox.Show("number of vowels is" + sug.Count);
            MessageBox.Show("most used vowel: " + vowels.GroupBy(x => x).OrderByDescending(xs => xs.Count()).Select(xs => xs.Key).First());
            MessageBox.Show("most used constant: " + sug.GroupBy(x => x).OrderByDescending(xs => xs.Count()).Select(xs => xs.Key).First());
        }
