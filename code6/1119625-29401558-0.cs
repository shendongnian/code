    public class PictureBoxNoFlicker : PictureBox {
		public PictureBoxNoFlicker() {
			this.SetStyle(ControlStyles.DoubleBuffer, true);
			this.SetStyle(ControlStyles.UserPaint, true);
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
		}
	} 
