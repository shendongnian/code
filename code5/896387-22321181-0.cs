    namespace ABC
    {
        public class LookUpEditEx : LookUpEdit
        {
            public static readonly DependencyProperty CustomFilterCommandProperty =
            DependencyProperty.Register("CustomFilterCommand", typeof(ICommand), typeof(LookUpEditEx),
            new PropertyMetadata(null));
    
            public ICommand CustomFilterCommand
            {
                get
                {
                    return (ICommand)GetValue(CustomFilterCommandProperty);
                }
                set
                {
                    SetValue(CustomFilterCommandProperty, value);
                }
            }
    
            protected override void OnAutoSearchTextChanged(string displayText)
            {            
                if (CustomFilterCommand != null)
                    CustomFilterCommand.Execute(displayText);
            }
        }
    }
