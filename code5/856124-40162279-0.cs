    public class PaddedLabel : UILabel
    {
        private readonly float _top;
        private readonly float _left;
        private readonly float _right;
        private readonly float _bottom;
        public PaddedLabel(float top, float left, float right, float bottom)
        {
            _top = top;
            _left = left;
            _right = right;
            _bottom = bottom;
        }
        public override CGSize IntrinsicContentSize => new CGSize(
            base.IntrinsicContentSize.Width + _left + _right,
            base.IntrinsicContentSize.Height + _top + _bottom
        );
    }
