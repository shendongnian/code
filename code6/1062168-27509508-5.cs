	public class UsefulScrollView : ScrollView
	{
		public EventHandler<UsefulScrollEventArgs> ScrollEventHandler { get; set; }
		public UsefulScrollView (Context context)
        : base(context)
		{
			ScrollEventHandler = (object sender, UsefulScrollEventArgs e) => {};
		}
		public UsefulScrollView (Context context, IAttributeSet attrs)
        : base(context, attrs) {
			ScrollEventHandler = (object sender, UsefulScrollEventArgs e) => {};
		}
		public UsefulScrollView(Context context, IAttributeSet attrs, int defStyle)
        : base(context, attrs, defStyle) {
			ScrollEventHandler = (object sender, UsefulScrollEventArgs e) => {};
		}
		protected override void OnScrollChanged(int l, int t, int oldl, int oldt)
		{
			ScrollEventHandler (this, 
                       new UsefulScrollEventArgs ()
                       {l=l,t=t,oldl=oldl,oldt=oldt});
			base.OnScrollChanged (l, t, oldl, oldt);
		}
		protected override void OnDraw(Android.Graphics.Canvas canvas)
		{
		}
	}
