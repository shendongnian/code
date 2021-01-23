    public sealed class TextBoxHelper: TextBox
    {
    	public static readonly DependencyProperty MyCaretIndexProperty
    								= DependencyProperty.Register
    									(
    										"MyCaretIndex", 
    										typeof(int), 
    										typeof(TextBoxHelper),
    										new FrameworkPropertyMetadata
    												(
    													0, 
    													FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, 
    													MyCaretIndexChanged
    												)
    									);
    
    	public static int GetMyCaretIndex(DependencyObject obj)
    	{
    		return (int)obj.GetValue(MyCaretIndexProperty);
    	}
    
    	public static void SetMyCaretIndex(DependencyObject obj, int value)
    	{
    		obj.SetValue(MyCaretIndexProperty, value);
    	}
    
    	public int MyCaretIndex
    	{
    		get { return (int)GetValue(MyCaretIndexProperty); }
    		set { SetValue(MyCaretIndexProperty, value); }
    	}
    
    	protected override void OnTextChanged(TextChangedEventArgs e)
    	{
    		base.OnTextChanged(e);
    		MyCaretIndex = base.CaretIndex;
    	}
    
    	protected override void OnKeyDown(KeyEventArgs e)
    	{
    		base.OnKeyDown(e);
    		MyCaretIndex = base.CaretIndex;
    	}
    
    	protected override void OnKeyUp(KeyEventArgs e)
    	{
    		base.OnKeyUp(e);
    		MyCaretIndex = base.CaretIndex;
    	}
    
    	protected override void OnMouseDown(MouseButtonEventArgs e)
    	{
    		base.OnMouseDown(e);
    		MyCaretIndex = base.CaretIndex;
    	}
    
    	protected override void OnMouseUp(MouseButtonEventArgs e)
    	{
    		base.OnMouseUp(e);
    		MyCaretIndex = base.CaretIndex;
    	}
    
    	private static void MyCaretIndexChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
    	{
    		if (obj is TextBox)
    		{
    			((TextBox)obj).CaretIndex = (int)e.NewValue;
    		}
    	}
    }
