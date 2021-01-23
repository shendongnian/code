        public static readonly DependencyProperty MyPropertyProperty =
            System.Windows.DependencyProperty.Register("MyProperty", typeof(string), typeof(MyClass), new PropertyMetadata(default(string), (
                sender, args) =>
            {
                //changed callback
                    var @this = (MyClass)sender;
                    var newval = (string)args.NewValue;
                    var oldval = (string)args.NewValue;
                    // do whatever you like
                },
                (s, e) =>
                    {
                        // coerce callback
                        if (e == null)
                            return " - empty string -";
                        return e;
                    }));
