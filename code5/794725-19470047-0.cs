    public Button[] AllButtons()
        {
            var buttons = new List<Button>();
            foreach (var control in this.Controls)
            {
                if (control.GetType() == typeof(Button))
                    buttons.Add((Button)control);
            }
            return buttons.ToArray();
        }
