    var sum = this.Controls.OfType<TextBox>()
        .Where(t => char.IsDigit(t.Name.Reverse().Take(1).FirstOrDefault())
            && t.Enabled)
        .Select(t =>
        {
            double i;
            if (!double.TryParse(t.Text, out i)) { return 0d; }
            return i / 100d;
        })
        .Sum();
