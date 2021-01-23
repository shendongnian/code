    private class CustomListItem
    {
        public string DisplayText { get; private set; }
        public int DollarValue { get; private set; }
        public CustomListItem(string text)
        {
            this.DisplayText = text;
            this.DollarValue = GetDollarValueFromString(text);
        }
        private int GetDollarValueFromString(string input)
        {
            if (input == null) return 0;
            int dollarValue = 0;
            int start = input.IndexOf('(');
            int end = input.IndexOf('$');
            if (start > -1 && end > start)
            {
                int.TryParse(
                    input.Substring(++start, end - start), 
                    out dollarValue);
            }
            return dollarValue;
        }
        public override string ToString()
        {
            return DisplayText;
        }
    }
