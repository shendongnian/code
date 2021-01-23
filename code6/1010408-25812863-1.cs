            StringBuilder allEntries = new StringBuilder();
            foreach (DictionaryEntry DE in Info)
            {
                allEntries.Append(DE.Key);
                allEntries.Append(DE.Value);
            }
            label4.Text = allEntries.ToString();
