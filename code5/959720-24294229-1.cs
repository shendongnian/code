    /// <summary>
	/// Provides data for the DoubleBufferedControl.Paint event
	/// </summary>
	public class DoubleBufferedPaintEventArgs : PaintEventArgs
	{
		/// <summary>
		/// Initializes a DoubleBufferedPaintEventArgs
		/// </summary>
		/// <param name="g">The Graphics object to paint to;  If the control is double buffered, the graphics object is for the buffer otherwise the screens graphics is used</param>
		/// <param name="clip">The region in which to paint</param>
		public DoubleBufferedPaintEventArgs(Graphics g, Rectangle clip) : base(g, clip) { }
	}
	public delegate void BufferedPaintEventHandler(object sender, DoubleBufferedPaintEventArgs args);
