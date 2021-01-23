    public class MyCheckBox : CheckBox
    {
        #region ImageNormal
        /// <summary>
        /// ImageNormal Dependency Property
        /// </summary>
        public static readonly DependencyProperty ImageNormalProperty =
            DependencyProperty.Register("ImageNormal", typeof(ImageSource), typeof(MyCheckBox),
                new FrameworkPropertyMetadata((ImageSource)null));
        /// <summary>
        /// Gets or sets the ImageNormal property. This dependency property 
        /// indicates ....
        /// </summary>
        public ImageSource ImageNormal
        {
            get { return (ImageSource)GetValue(ImageNormalProperty); }
            set { SetValue(ImageNormalProperty, value); }
        }
        #endregion
        #region ImageChecked
        /// <summary>
        /// ImageChecked Dependency Property
        /// </summary>
        public static readonly DependencyProperty ImageCheckedProperty =
            DependencyProperty.Register("ImageChecked", typeof(ImageSource), typeof(MyCheckBox),
                new FrameworkPropertyMetadata((ImageSource)null));
        /// <summary>
        /// Gets or sets the ImageChecked property. This dependency property 
        /// indicates ....
        /// </summary>
        public ImageSource ImageChecked
        {
            get { return (ImageSource)GetValue(ImageCheckedProperty); }
            set { SetValue(ImageCheckedProperty, value); }
        }
        #endregion
        //... other image properties removed for simplicity
        static MyCheckBox()
        {
            //Override base class style
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyCheckBox), new FrameworkPropertyMetadata(typeof(MyCheckBox)));
        }
    }
