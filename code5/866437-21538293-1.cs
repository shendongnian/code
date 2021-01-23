    public static readonly DependencyProperty WorkIDProperty = 
    DependencyProperty.Register("WorkID", typeof(int), typeof(ActionNotes));
    public int WorkID
    {
        get { return (int)GetValue(WorkIDProperty); }
        set { SetValue(WorkIDProperty, value); }
    }
