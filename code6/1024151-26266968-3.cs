    private Dictionary<string, Button> DynamicButtons = new Dictionary<string, Button>();
    private void ClickDictionaryButton(string buttonName) {
            var matches = DynamicButtons.Where(x => x.Key.Contains(buttonName));
            foreach (var match in matches) {
                match.Value.PerformClick();
            }
    }
