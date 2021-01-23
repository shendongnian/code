    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Media;
    
    namespace System.Windows.Controls
    {
        [StyleTypedProperty(Property = "WatermarkTextStyle", StyleTargetType = typeof(TextBlock)),
        TemplatePart(Name = "WatermarkText", Type = typeof(TextBlock)),
        TemplateVisualState(Name = "WatermarkTextVisible", GroupName = "WatermarkTextStates"),
        TemplateVisualState(Name = "WatermarkTextHidden", GroupName = "WatermarkTextStates")]
        public class WatermarkTextBox : TextBox
        {
    
            public static readonly DependencyProperty WatermarkTextProperty = DependencyProperty.Register(
                "WatermarkText",
                typeof(string),
                typeof(WatermarkTextBox),
                new PropertyMetadata("", OnWatermarkTextPropertyChanged));
    
            public static readonly DependencyProperty WatermarkTextForegroundProperty = DependencyProperty.Register(
                "WatermarkTextForeground",
                typeof(Brush),
                typeof(WatermarkTextBox),
                new PropertyMetadata(new SolidColorBrush(Colors.Gray), OnWatermarkTextForegroundPropertyChanged));
    
            public static readonly DependencyProperty WatermarkTextStyleProperty = DependencyProperty.Register(
                "WatermarkTextStyle",
                typeof(Style),
                typeof(WatermarkTextBox),
                new PropertyMetadata(null, OnWatermarkTextStylePropertyChanged));
    
    
    
            private bool itsIsFocused = false;
    
            public string WatermarkText
            {
                get { return (string)this.GetValue(WatermarkTextProperty); }
                set { this.SetValue(WatermarkTextProperty, value); }
            }
    
            public Brush WatermarkTextForeground
            {
                get { return (Brush)this.GetValue(WatermarkTextForegroundProperty); }
                set { this.SetValue(WatermarkTextForegroundProperty, value); }
            }
    
            public Style WatermarkTextStyle
            {
                get { return (Style)this.GetValue(WatermarkTextStyleProperty); }
                set { this.SetValue(WatermarkTextStyleProperty, value); }
            }
    
    
    
            private static void OnWatermarkTextPropertyChanged(DependencyObject theTarget, DependencyPropertyChangedEventArgs theDependencyPropertyChangedEventArgs)
            {
                // Do nothing
            }
    
            private static void OnWatermarkTextForegroundPropertyChanged(DependencyObject theTarget, DependencyPropertyChangedEventArgs theDependencyPropertyChangedEventArgs)
            {
                // Do nothing
            }
    
            private static void OnWatermarkTextStylePropertyChanged(DependencyObject theTarget, DependencyPropertyChangedEventArgs theDependencyPropertyChangedEventArgs)
            {
                // Do nothing
            }
    
    
    
            public WatermarkTextBox()
                : base()
            {
                this.DefaultStyleKey = typeof(WatermarkTextBox);
    
                this.GotFocus += new RoutedEventHandler(WatermarkTextBox_GotFocus);
                this.LostFocus += new RoutedEventHandler(WatermarkTextBox_LostFocus);
                this.Loaded += new RoutedEventHandler(WatermarkTextBox_Loaded);
                this.TextChanged += new TextChangedEventHandler(WatermarkTextBox_TextChanged);
            }
    
            private void WatermarkTextBox_Loaded(object sender, RoutedEventArgs e)
            {
                this.GoToVisualState(true);
            }
    
            private void WatermarkTextBox_GotFocus(object sender, RoutedEventArgs e)
            {
                this.itsIsFocused = true;
                this.GoToVisualState(false);
            }
    
            private void WatermarkTextBox_LostFocus(object sender, RoutedEventArgs e)
            {
                this.itsIsFocused = false;
                this.GoToVisualState(true);
            }
    
            private void WatermarkTextBox_TextChanged(object sender, TextChangedEventArgs e)
            {
                if (!this.itsIsFocused)
                {
                    this.GoToVisualState(false);
                }
            }
    
            private void GoToVisualState(bool theIsWatermarkDisplayed)
            {
                if (theIsWatermarkDisplayed && (this.Text == null || (this.Text != null && this.Text.Length == 0)))
                {
                    VisualStateManager.GoToState(this, "WatermarkTextVisible", true);
                }
                else
                {
                    VisualStateManager.GoToState(this, "WatermarkTextHidden", true);
                }
            }
        }
    }
