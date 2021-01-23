    public class VerticalProgressBar : ProgressBar
    {
        protected VerticalProgressBar(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }
    
        public VerticalProgressBar(Context context) : base(context)
        {
        }
    
        public VerticalProgressBar(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }
    
        public VerticalProgressBar(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
        {
        }
    
        protected override void OnSizeChanged (int w, int h, int oldw, int oldh)
	{
		base.OnSizeChanged (h, w, oldh, oldw); //Fixes the width-height issue
	}
	public override void Draw(Android.Graphics.Canvas canvas)
	{
		canvas.Rotate(-90); //Rotating the canvas around (0,0) point of the control
		canvas.Translate(-Height, 0); //Moving the canvas inside the control rect
		base.OnDraw(canvas);
	}
    }
