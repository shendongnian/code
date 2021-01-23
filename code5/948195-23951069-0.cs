    public abstract class ReusableUIElement3D : UIElement3D
    {
        public static readonly DependencyProperty ModelProperty = DependencyProperty.Register("Model", typeof (Model3D),
            typeof (ReusableUIElement3D), new PropertyMetadata(ModelPropertyChanged));
        public Model3D Model
        {
            get
            {
                return (Model3D)GetValue(ModelProperty);
            }
            set
            {
                SetValue(ModelProperty, value);
            }
        }
        protected override void OnUpdateModel()
        {
            this.Model = this.CreateElementModel();
        }
        protected virtual Model3D CreateElementModel()
        {
            return null;
        }
        protected static void VisualPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ReusableUIElement3D reusableElement = (ReusableUIElement3D)d;
            reusableElement.InvalidateModel();
        }
        protected static void ModelPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ReusableUIElement3D reusableElement = (ReusableUIElement3D)d;
            reusableElement.Visual3DModel = reusableElement.Model;
        }
    }
