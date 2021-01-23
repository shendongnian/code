        #region NumericKeyboard
        public static readonly DependencyProperty NumericKeyboardProperty = DependencyProperty.Register("NumericKeyboard", typeof(bool), typeof(CustomTextBox), new FrameworkPropertyMetadata(false));
        /// <summary> Returns/set the "NumericKeyboard" state of the CustomTextBox. </summary>
        public bool NumericKeyboard
        {
            get { return (bool)GetValue(NumericKeyboardProperty); }
            set { SetValue(NumericKeyboardProperty, value); }
        }
        #endregion
        protected override void OnTouchDown(TouchEventArgs e)
        {
            base.OnTouchDown(e);
            Focus();
            if (IsReadOnly == false)
                ShowTouchKeyboard(true, NumericKeyboard);
        }
