    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Media;
    
    namespace WpfApplication1.Controls
    {
        public class CustomTextBox : TextBox
        {
            public CustomTextBox()
            {
                this.Loaded += CustomTextBox_Loaded;
            }
    
            void CustomTextBox_Loaded(object sender, RoutedEventArgs e)
            {
                BindingExpression bindingExpression = GetBindingExpression(RefreshProperty);
                BindingMode mode = bindingExpression.ParentBinding.Mode;
    
                if (mode != BindingMode.OneWayToSource)
                {
                    Text = "Use OneWayToSource Binding only!";
                    Background = new SolidColorBrush(Colors.Red);
                }
    
                Refresh = new Action(DoRefresh);
            }
    
            private void DoRefresh()
            {
                Text = null;
            }
    
            public Action Refresh
            {
                get { return (Action)GetValue(RefreshProperty); }
                set { SetValue(RefreshProperty, value); }
            }
    
            public static readonly DependencyProperty RefreshProperty = DependencyProperty.Register("Refresh", typeof(Action), typeof(CustomTextBox));
        }
    }
