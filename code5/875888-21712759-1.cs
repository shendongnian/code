    public class MyGridView : DataGridView {
        public MyGridView() {
            this.BackgroundColor = DefaultBackgroundColor;
        }
        public new Color BackgroundColor {
            get { return base.BackgroundColor; }
            set { base.BackgroundColor = value;  }
        }
        private bool ShouldSerializeBackgroundColor() {
            return !this.BackgroundColor.Equals(DefaultBackgroundColor);
        }
         private void ResetBackgroundColor() {
            this.BackgroundColor = DefaultBackgroundColor;
        }
        private static Color DefaultBackgroundColor {
            get { return Color.Red; }
        }
    }
