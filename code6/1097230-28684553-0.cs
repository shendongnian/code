      <Window  my:MyBehaviour.DoSomethingWhenTouched="true" x:Class="MyProject.MainWindow">
    public static class MyBehaviour
    {
        public static readonly DependencyProperty  DoSomethingWhenTouchedProperty = DependencyProperty.RegisterAttached("DoSomethingWhenTouched", typeof(bool), typeof(MyBehaviour), 
            new FrameworkPropertyMetadata( DoSomethingWhenTouched_PropertyChanged));
    
        private static void  DoSomethingWhenTouched_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var uiElement = (UIElement)d;
                
            //unsibscribe firt to avoid multiple subscription
            uiElement.PreviewTouchUp -=uiElement_PreviewTouchUp;
    
            if ((bool)e.NewValue){
                uiElement.PreviewTouchUp +=uiElement_PreviewTouchUp;
            }
        }
    
        static void uiElement_PreviewTouchUp(object sender, System.Windows.Input.TouchEventArgs e)
        {
            //you logic goes here
        }
    
        //methods required by wpf conventions
        public static bool GetDoSomethingWhenTouched(UIElement obj)
        {
            return (bool)obj.GetValue(DoSomethingWhenTouchedProperty);
        }
    
        public static void SetDoSomethingWhenTouched(UIElement obj, bool value)
        {
            obj.SetValue(DoSomethingWhenTouchedProperty, value);
        }
    }
