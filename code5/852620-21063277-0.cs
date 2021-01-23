    public class ColorRules
    {
        private IEnumerable<ColorRuleEntry> _rules;
        public ColorRules()
        {
            _rules = InitialColorRules();
        }
        private IEnumerable<ColorRuleEntry> InitialColorRules()
        {
            yield return new ColorRuleEntry(1, Color.FromArgb(245, 244, 162), "1");
            yield return new ColorRuleEntry(2, Color.FromArgb(245, 244, 162), "2");
            yield return new ColorRuleEntry(3, Color.FromArgb(245, 244, 162), "3");
            yield return new ColorRuleEntry(4, Color.FromArgb(245, 244, 162), "4");
            // and so on
        }
        public bool TryGetResult(int button, Color backgroundColor, out String result)
        {
            var entry = _rules.FirstOrDefault(e => e.Button == button && e.Color.Equals(backgroundColor));
            if (entry == null)
            {
                result = null;
                return false;
            }
            result = entry.Result;
            return true;
        }
        protected class ColorRuleEntry
        {
            public ColorRuleEntry(int button, Color color, String result)
            {
                Button = button;
                Color = color;
                Result = result;
            }
            public Color Color { get; protected set; }
            public int Button { get; protected set; }
            public String Result { get; protected set; }
        }
    }
