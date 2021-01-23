    public class EndlessScroll : ScrollView
	{ 
		private ScrollViewListener scrollViewListener = null; 
		public EndlessScroll (Context context) : base (context) 
		{
			 
		}
		public EndlessScroll(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
		{
		}
		public EndlessScroll(Context context, IAttributeSet attrs) : base(context, attrs)
		{
		
			 
		}
	
		public interface ScrollViewListener
		{
			void OnScrollChanged(EndlessScroll v, int l, int t, int oldl, int oldt);
		}
	
		public void setOnScrollViewListener(ScrollViewListener scrollViewListener) {
			this.scrollViewListener = scrollViewListener;
		}
		protected override void OnScrollChanged(int l, int t, int oldl, int oldt)
		{
			 
			base.OnScrollChanged (l, t, oldl, oldt); 
			if (scrollViewListener != null) {
				scrollViewListener.OnScrollChanged (this, l, t, oldl, oldt);
			} 
		}
	}
