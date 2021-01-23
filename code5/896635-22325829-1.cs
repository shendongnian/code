    private void createRadioButtons(int amount, String answ)
    {
        ClearOldControls();
        // Create new ones
        _controls = answ.Split(new char[]{';'}, StringSplitOptions.RemoveEmptyEntries)
            .Take(amount)
            .Select(answer =>
            {
                var rb = new RadioButton();
                rb.Text = answer;
                this.Controls.Add(rb);
                return rb;
            });
    }
