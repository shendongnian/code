    private Dictionary<string, Button> DynamicButtons = new Dictionary<string, Button>();
    private void ClickDictionaryButton(string buttonName) {
            if (DynamicButtons.ContainsKey(buttonName)) {
                DynamicButtons[buttonName].PerformClick();
            }
    }
