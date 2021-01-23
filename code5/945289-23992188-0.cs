    public static readonly DependencyProperty SelectionLengthProperty =
         DependencyProperty.Register("SelectionLength", typeof(int), typeof(MvvmTextEditor),
         new PropertyMetadata((obj, args) =>
             {
                 MvvmTextEditor target = (MvvmTextEditor)obj;
                 if (target.SelectionLength != (int)args.NewValue)
                 {
                     target.SelectionLength = (int)args.NewValue;
                     target.Select(target.SelectionStart, (int)args.NewValue);
                 }
             }));
    public new int SelectionLength
    {
        get { return base.SelectionLength; }
        //get { return (int)GetValue(SelectionLengthProperty); }
        set { SetValue(SelectionLengthProperty, value); }
    }
    
