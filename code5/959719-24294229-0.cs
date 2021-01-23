    	/// <summary>
	/// Implements the functionality for a control that can be double buffered
	/// </summary>
	public class DoubleBufferableControl : ScrollableControl
	{
		public event BufferedPaintEventHandler BufferedPaint;
		private bool doubleBuffered;
		private Bitmap backBuffer;
		private Size oldSize;
		/// <summary>
		/// Gets or sets whether this control will use double buffering
		/// </summary>
		public bool DoubleBuffered
		{
			get
			{
				return doubleBuffered;
			}
			set
			{
				if (value && !doubleBuffered && Width > 0 && Height > 0)
				{
					backBuffer = new Bitmap(Width, Height);
				}
				else if(!value && doubleBuffered)
				{
					backBuffer.Dispose();
					backBuffer = null;
				}
				
				doubleBuffered = value;
			}
		}
		/// <summary>
		/// Gets the off screen image used for double buffering
		/// </summary>
		public Bitmap BackBuffer
		{
			get
			{
				return backBuffer;
			}
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="DoubleBufferableControl"/> class.
		/// </summary>
		public DoubleBufferableControl()
		{
			AutoScroll = false;
			doubleBuffered = DefaultDoubleBuffered;
			oldSize = Size;
		}
		
		#region Designer
		private bool DefaultDoubleBuffered = false;
		protected virtual bool ShouldSerializeDoubleBuffered()
		{
			return !this.doubleBuffered.Equals(DefaultDoubleBuffered);
		}
		protected void ResetDoubleBuffered()
		{
			DoubleBuffered = DefaultDoubleBuffered;
		}
		#endregion
		/// <summary>
		/// Raises the Paint event
		/// </summary>
		/// <param name="e">A PaintEventArgs that represents event data</param>
		protected override sealed void OnPaint(PaintEventArgs e)
		{
			if (doubleBuffered)
			{
				DoubleBufferedPaintEventArgs pe = new DoubleBufferedPaintEventArgs(CreateGraphics(), e.ClipRectangle);
				OnPaint(pe);
				pe.Graphics.Dispose();
				e.Graphics.DrawImage(backBuffer, e.ClipRectangle, e.ClipRectangle, GraphicsUnit.Pixel);
				base.OnPaint(e);
			}
			else
			{
				DoubleBufferedPaintEventArgs pe = new DoubleBufferedPaintEventArgs(e.Graphics, e.ClipRectangle);
				OnPaint(pe);
				base.OnPaint(e);
			}
		}
		/// <summary>
		/// Raises the Paint event for child classes that are to be double buffered
		/// </summary>
		/// <param name="e"></param>
		protected virtual void OnPaint(DoubleBufferedPaintEventArgs e)
		{
			if (BufferedPaint != null)
				BufferedPaint(this, e);
		}
		/// <summary>
		/// Paints the background of the control
		/// </summary>
		/// <param name="e">A PaintEventArgs object that contains event data</param>
		protected override void OnPaintBackground(PaintEventArgs e)
		{
			// do not use arg, because can't control back/screen
			Graphics gfx = CreateGraphics();
			gfx.Clear(BackColor);
			gfx.Dispose();
		}
		/// <summary>
		/// Raises the Resize event
		/// </summary>
		/// <param name="e">An EventArgs that represents event data</param>
		protected override void OnResize(System.EventArgs e)
		{
			if (Size != oldSize) // Stupid control gets resized when like anything happens to the parent form
			{
				if (doubleBuffered)
				{
					if (backBuffer != null)
						backBuffer.Dispose();
					backBuffer = new Bitmap(Width != 0 ? Width : 1, Height != 0 ? Height : 1);
				}
			}
			oldSize = Size;
			base.OnResize(e);
		}
		/// <summary>
		/// Creates the Graphics for the control
		/// </summary>
		/// <param name="backBuffer">True to bypass the buffer and get the control graphics</param>
		/// <returns></returns>
		public virtual Graphics CreateGraphics(bool bypass)
		{
			if(bypass || !doubleBuffered)
				return base.CreateGraphics();
			else
				return Graphics.FromImage(backBuffer);
		}
		public virtual new Graphics CreateGraphics()
		{
			return CreateGraphics(false);
		}
	}
