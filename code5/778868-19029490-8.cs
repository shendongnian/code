    public class PosTextBox : TextBox
    {
        public PosTextBox()
        {
        }
        public static readonly DependencyProperty PosTypeProperty =
            DependencyProperty.Register("PosType", typeof (string), typeof (PosTextBox), new PropertyMetadata(default(string)));
        public string PosType
        {
            get { return (string)GetValue(PosTypeProperty); }
            set { SetValue(PosTypeProperty, value); }
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var layer = AdornerLayer.GetAdornerLayer(this);
            var posAdorner = new PosTypeAdorner(this, PosType);
            layer.Add(posAdorner);
        }
    }
