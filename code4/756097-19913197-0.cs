    public partial class CustomTextField : NSTextField
	{
		#region Constructors
		// Called when created from unmanaged code
		public CustomTextField (IntPtr handle) : base (handle)
		{
			Initialize ();
		}
		// Called when created directly from a XIB file
		[Export ("initWithCoder:")]
		public CustomTextField (NSCoder coder) : base (coder)
		{
			Initialize ();
		}
		// Shared initialization code
		void Initialize ()
		{
		}
		#endregion
		public override void RightMouseDown (NSEvent theEvent)
		{
			NextResponder.RightMouseDown (theEvent);
		}
	}
