    [System.ComponentModel.ToolboxItem (true)]
	public partial class ImageControl : Gtk.Bin
	{
		private Pixbuf original;
		private bool resized;
		public Gdk.Pixbuf Pixbuf {
			get
			{ 
				return image.Pixbuf;
			}
			set
			{ 
				original = value;
				image.Pixbuf = value;
			}
		}
		public ImageControl ()
		{
			this.Build ();
		}
		protected override void OnSizeAllocated (Gdk.Rectangle allocation)
		{
			if ((image.Pixbuf != null) && (!resized)) {
				var srcWidth = original.Width;
				var srcHeight = original.Height;
				int resultWidth, resultHeight;
				ScaleRatio (srcWidth, srcHeight, allocation.Width, allocation.Height, out resultWidth, out resultHeight);
				image.Pixbuf = original.ScaleSimple (resultWidth, resultHeight, InterpType.Bilinear);
				resized = true;
			} else {
				resized = false;
				base.OnSizeAllocated (allocation);
			}
		}
		private static void ScaleRatio(int srcWidth, int srcHeight, int destWidth, int destHeight, out int resultWidth, out int resultHeight)
		{
			var widthRatio = (float)destWidth / srcWidth;
			var heigthRatio = (float)destHeight / srcHeight;
			var ratio = Math.Min(widthRatio, heigthRatio);
			resultHeight = (int)(srcHeight * ratio);
			resultWidth = (int)(srcWidth * ratio);
		}
	}
