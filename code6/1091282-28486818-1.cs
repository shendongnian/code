    public class ButtonEx : LinearLayout
    {
        ImageView imageView = null;
        TextView textView = null;
        LinearLayout.LayoutParams imageParams = null;
        LinearLayout.LayoutParams labelParams = null;
        public new Object Tag
        { get; set; }
        private String _Text = "";
        public String Text
        {
            get
            {
                return _Text;
            }
            set
            {
                if (textView != null)
                    textView.Text = value;
                _Text = value;
            }
        }
        private Color _TextColor = Color.White;
        public Color TextColor
        {
            get
            {
                return _TextColor;
            }
            set
            {
                if (textView != null)
                    textView.SetTextColor(value);
                _TextColor = value;
            }
        }
        private float _TextSize = 12f;
        public float TextSize
        {
            get
            {
                return _TextSize;
            }
            set
            {
                if (textView != null)
                    textView.TextSize = value;
                _TextSize = value;
            }
        }
        public Drawable _Image = null;
        public Drawable Image
        {
            get
            {
                return _Image;
            }
            set
            {
                if (imageView != null)
                    imageView.Background = value;
                _Image = value;
            }
        }
        public ButtonEx(Context context)
            : base(context)
        {
            TransitionDrawable buttonTransition =
                (TransitionDrawable)Resources.GetDrawable(Resource.Drawable.button_transition);
            LinearLayout.LayoutParams layoutParams =
                new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, Android.DpToPx(45, context));
            this.Background = buttonTransition;
            this.LayoutParameters = layoutParams;
            this.Orientation = Orientation.Horizontal;
            imageParams =
                new LinearLayout.LayoutParams(
                    Android.DpToPx(45, context), 
                    LinearLayout.LayoutParams.MatchParent);
            labelParams =
                new LinearLayout.LayoutParams(
                    LinearLayout.LayoutParams.MatchParent, 
                    LinearLayout.LayoutParams.MatchParent);
            imageView = new ImageView(context)
            {
                LayoutParameters = imageParams,
            };
            imageView.SetScaleType(ImageView.ScaleType.CenterInside);
            this.AddView(imageView);
            textView = new TextView(context)
            {
                LayoutParameters = labelParams,
                Gravity = GravityFlags.CenterVertical,
            };
            this.AddView(textView);
        }
    }
