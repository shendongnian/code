      public class MyRichTextBox : RichTextBox
        {
            public static readonly DependencyProperty RichTextProperty = DependencyProperty.Register("RichText", typeof(Paragraph), typeof(MyRichTextBox), new PropertyMetadata(null, RichTextPropertyChanged));
    
            public Paragraph RichText
            {
                get 
                { 
                    return (Paragraph)GetValue(RichTextProperty); 
                }
    
                set 
                { 
                    SetValue(RichTextProperty, value); 
                }
            }
    
            private static void RichTextPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
            {
                MyRichTextBox richTextBox = (MyRichTextBox)dependencyObject;
                Paragraph paragraph = (Paragraph)dependencyPropertyChangedEventArgs.NewValue;
    
                // Remove any existing content from the text box
                richTextBox.Blocks.Clear();
    
                // Add the paragraph to the text box
                richTextBox.Blocks.Add(paragraph);
            }
        }
    }
