    public class CustomNumericUpDown : NumericUpDown
    {
      protected override void UpdateEditText()
      {
        this.Text = this.Value.ToString() + "%";
      }
    }
