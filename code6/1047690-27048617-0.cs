    private class CustomListItem
    {
        public string DisplayText { get; private set; }
        public int DollarValue { get; private set; }
        public CustomListItem(string text)
        {
            this.DisplayText = text;
            this.DollarValue = getDollarValueFromString(text);
        }
        private int getDollarValueFromString(string input)
        {
            if (input == null) return 0;
            int dollarValue = 0;
            int startInt = input.IndexOf('(');
            int endInt = input.IndexOf('$');
            if (startInt > -1 && endInt > startInt)
            {
                int.TryParse(
                    input.Substring(++startInt, endInt - startInt), 
                    out dollarValue);
            }
            return dollarValue;
        }
        public override string ToString()
        {
            return DisplayText;
        }
    }
