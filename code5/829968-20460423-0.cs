    int CalculateTotal (RadioButton radioButton, int currentTotal)
    {
        if (radioButton.Checked)
            return 0;
        var elements = new[]
            {
                new
                    {
                        CheckBoxButton = chkFire,
                        Value = 50000
                    },
                new
                    {
                        CheckBoxButton = chkMarbled,
                        Value = 500
                    }
                // and so on
            };
        return currentTotal + elements.TakeWhile(x => x.CheckBoxButton.Checked).Sum(x => x.Value);
    }
