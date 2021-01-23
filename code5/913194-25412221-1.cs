    using System.Windows;
    using System.Windows.Controls;
    
    namespace TestAttachedPropertyValidationError
    {
    	public class TextBoxCustomControl : Control
    	{
    		static TextBoxCustomControl()
    		{
    			DefaultStyleKeyProperty.OverrideMetadata(typeof(TextBoxCustomControl), new FrameworkPropertyMetadata(typeof(TextBoxCustomControl)));
    		}
    
    		public static readonly DependencyProperty NumericPropProperty =
    			DependencyProperty.Register("NumericProp", typeof (int), typeof (TextBoxCustomControl), new PropertyMetadata(default(int)));
    
    		public int NumericProp
    		{
    			get { return (int) GetValue(NumericPropProperty); }
    			set { SetValue(NumericPropProperty, value); }
    		}
    
    		public static readonly DependencyProperty NumericPropHasErrorProperty =
    			DependencyProperty.Register("NumericPropHasError", typeof (bool), typeof (TextBoxCustomControl), new PropertyMetadata(default(bool)));
    
    		public bool NumericPropHasError
    		{
    			get { return (bool) GetValue(NumericPropHasErrorProperty); }
    			set { SetValue(NumericPropHasErrorProperty, value); }
    		}
    	}
    }
