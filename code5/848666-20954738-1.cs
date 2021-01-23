    var sum = this.Controls.OfType<TextBox>()
        .Where(t => char.IsDigit(t.Name.Reverse().Take(1).FirstOrDefault()))
        .Select(t =>
        {
            double i;
            if (!double.TryParse(t.Text, out i)) { return 0d; }
            return i;
        })
        .Sum();
    var res = sum / 100d;
