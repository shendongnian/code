     public int SelectionLength
            {
                get { return (int)GetValue(SelectionLengthProperty); }
                set { SetValue(SelectionLengthProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for SelectionLength.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty SelectionLengthProperty =
                DependencyProperty.Register("SelectionLength", typeof(int), typeof(MvvmTextEditor), new PropertyMetadata(0,));
    
            
            private static void SelectionLengthPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
            {
                var textEditor = obj as MvvmTextEditor;
    
                textEditor.SelectionLength = e.NewValue;
            }
