    public class SetFocusToBindingBehavior : Behavior<FrameworkElement>
    {
        public static readonly DependencyProperty SetFocusToBindingPathProperty =
          DependencyProperty.Register("SetFocusToBindingPath", typeof(string), typeof(SetFocusToBindingBehavior ), new FrameworkPropertyMetadata(SetFocusToBindingPathPropertyChanged));
        
        public string SetFocusToBindingPath
        {
            get { return (string)GetValue(SetFocusToBindingPathProperty); }
            set { SetValue(SetFocusToBindingPathProperty, value); }
        }
        private static void SetFocusToBindingPathPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var behavior = d as SetFocusToBindingBehavior;
            var bindingpath = (e.NewValue as string) ?? string.Empty;
            if (behavior == null || string.IsNullOrWhiteSpace(bindingpath))
                return;
            behavior.SetFocusTo(behavior.AssociatedObject, bindingpath);
            //wenn alles vorbei ist dann binding path zurücksetzen auf string.empty, 
            //ansonsten springt PropertyChangedCallback nicht mehr an wenn wieder zum gleichen Propertyname der Focus gesetzt werden soll
            behavior.SetFocusToBindingPath = string.Empty;
        }
        private void SetFocusTo(DependencyObject obj, string bindingpath)
        {
            if (string.IsNullOrWhiteSpace(bindingpath)) 
                return;
            var ctrl = CheckForBinding(obj, bindingpath);
            if (ctrl == null || !(ctrl is IInputElement))
                return;
            var iie = (IInputElement) ctrl;
            ctrl.Dispatcher.BeginInvoke((Action)(() =>
                {
                    if (!iie.Focus())
                    {
                        //zb. bei IsEditable=true Comboboxen funzt .Focus() nicht, daher Keyboard.Focus probieren
                        Keyboard.Focus(iie);
                        if (!iie.IsKeyboardFocusWithin)
                        {
                            Debug.WriteLine("Focus konnte nicht auf Bindingpath: " + bindingpath + " gesetzt werden.");
                            var tNext = new TraversalRequest(FocusNavigationDirection.Next);
                            var uie = iie as UIElement;
                            if (uie != null)
                            {
                                uie.MoveFocus(tNext);
                            } 
                        }
                    }
                }), DispatcherPriority.Background);
        }
        public string BindingName { get; set; }
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Loaded += AssociatedObjectLoaded;
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.Loaded -= AssociatedObjectLoaded;
        }
        private void AssociatedObjectLoaded(object sender, RoutedEventArgs e)
        {
            SetFocusTo(AssociatedObject, this.BindingName);
        }
        private DependencyObject CheckForBinding(DependencyObject obj, string bindingpath)
        {
            var properties = TypeDescriptor.GetProperties(obj, new Attribute[] { new PropertyFilterAttribute(PropertyFilterOptions.All) });
            if (obj is IInputElement && ((IInputElement) obj).Focusable)
            {
                foreach (PropertyDescriptor property in properties)
                {
                    var prop = DependencyPropertyDescriptor.FromProperty(property);
                    if (prop == null) continue;
                    var ex = BindingOperations.GetBindingExpression(obj, prop.DependencyProperty);
                    if (ex == null) continue;
                    if (ex.ParentBinding.Path.Path == bindingpath)
                        return obj;
                    
                }
            }
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                var result = CheckForBinding(VisualTreeHelper.GetChild(obj, i),bindingpath);
                if (result != null)
                    return result;
            }
            return null;
        }
    }
