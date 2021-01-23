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
    
        public override void Draw(Android.Graphics.Canvas canvas)
        {
            canvas.Rotate(-90);
            canvas.Translate(-Height, 0);
            base.OnDraw(canvas);
        }
    }
