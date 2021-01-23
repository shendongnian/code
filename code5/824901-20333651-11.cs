    private static void MyCaretIndexChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
    {
    	if (obj is TextBox && (int)e.OldValue != (int)e.NewValue)
    	{
    		var textBox = (TextBox) obj;
    		textBox.CaretIndex = (int)e.NewValue;
    		if (!string.IsNullOrEmpty(textBox.Text))
    			textBox.Select(textBox.CaretIndex, textBox.Text.Length - textBox.CaretIndex);
    	}
    }
