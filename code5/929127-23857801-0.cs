        public class TextBoxDependencyWrapper : TextBox
        {
            public static readonly DependencyProperty CaretIndexProperty = DependencyProperty.Register(
                "CaretIndex", typeof (int), typeof (TextBoxDependencyWrapper), new FrameworkPropertyMetadata(default(int), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, CaretIndexChanged ));
            protected override void OnKeyUp(KeyEventArgs e) //Event that changes the property we're trying to track
            {
                base.OnKeyUp(e);
                CaretIndex = base.CaretIndex;
            }
            protected override void OnKeyDown(KeyEventArgs e) //Event that changes the property we're trying to track
            {
                base.OnKeyDown(e);
                CaretIndex = base.CaretIndex;
            }
            public new int CaretIndex
            {
                get { return (int) GetValue(CaretIndexProperty); }
                set { SetValue(CaretIndexProperty, value); }
            }
        }
