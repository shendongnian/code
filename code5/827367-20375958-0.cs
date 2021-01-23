    string extractPattern = "(?<Name>.*) :Qty (?<Qty>.*) :Tax (?<Tax>.*)";
            foreach (var item in (comboBox1.DataSource as List<string>))
            {
                var matches = Regex.Match(item, extractPattern);
                if (matches.Groups["Name"].Success)
                {
                    MessageBox.Show(matches.Groups["Name"].Value);
                }
                if (matches.Groups["Qty"].Success)
                {
                    MessageBox.Show(matches.Groups["Qty"].Value);
                }
                if (matches.Groups["Tax"].Success)
                {
                    MessageBox.Show(matches.Groups["Tax"].Value);
                }
            }
