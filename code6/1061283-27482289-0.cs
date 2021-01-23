     public string Text
            {
                get { return (string)GetValue(TextProperty); }
                set { SetValue(TextProperty, value); }
            }
            public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(MyClass), new PropertyMetadata(string.Empty,valueChanged));
            private static void valueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                MyClass c = d as MyClass;
                if(c!=null)
                {
                    var array = e.NewValue.ToString().Split(':');
                    c.Text1 = array[0];
                    c.Text2 = array[1];
                }
            }
