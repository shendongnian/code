    class MyClass
    {
        public static readonly string InitializeFailureMessageProperty = GetPropertyName(() => x.InitializeFailureMessageProperty);//x can be a dummy instance.
    }
    
    void ViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == MyClass.InitializeFailureMessageProperty)
        {
             if (Vm.InitializeFailureMessage != null)
                 ShowInitializeFailure(Vm.InitializeFailureMessage);
        }
    }
