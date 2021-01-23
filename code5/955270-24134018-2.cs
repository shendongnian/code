        List<string> _List = new List<string>();
        private void richTextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            string _Text = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd).Text;
            for (int count = 0; count < _List.Count; count++)
            {
                string[] _Split = _List[count].Split(','); //Separate each string in _List[count] based on its index
                _Text = _Text.Replace(_Split[0], _Split[1]); //Replace the first index with the second index
            }
            if (_Text != new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd).Text)
            {
            new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd).Text = _Text;
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // The comma will be used to separate multiple items
            _List.Add("pc,Personal Computer");
            _List.Add("sc,Star Craft");
           
        }
