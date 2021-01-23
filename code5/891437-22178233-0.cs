    public static DependencyProperty CtrlButtonCollectionProperty =
                DependencyProperty.Register(
                    "CtrlButtonCollection",
                    typeof(IList<Button>),
                    typeof(MessageBoxModule),
                    new PropertyMetadata(new List<Button>())); <-- HERE
