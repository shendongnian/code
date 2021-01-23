    public static readonly DependencyProperty ActualPersonProperty = DependencyProperty.Register(
        "ActualPerson", typeof (Person), typeof (MyUserControl), new PropertyMetadata(default(Person)));
    public Person ActualPerson
    {
        get { return (Person) GetValue(ActualPersonProperty); }
        set { SetValue(ActualPersonProperty, value); }
    }
