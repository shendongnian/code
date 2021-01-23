    protected override void UpdateEditText() {
      if (string.IsNullOrWhiteSpace(Units)) {
        base.UpdateEditText();
      } else {
        try {
          Value = Math.Max(Math.Min(decimal.Parse(Text.Replace(Units, "").Trim()), Maximum), Minimum);
        } catch {
          base.UpdateEditText();
        }
        this.Text = this.Value + " " + Units;
      }
    }
