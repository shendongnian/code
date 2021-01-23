    protected override void UpdateEditText() {
      if (string.IsNullOrWhiteSpace(Units)) {
        base.UpdateEditText();
      } else {
        try {
          Value = decimal.Parse(Text.Replace(Units, "").Trim());
        } catch {
          base.UpdateEditText();
        }
        this.Text = this.Value + " " + Units;
      }
    }
