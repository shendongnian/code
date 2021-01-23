    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public void InitializeComponent()
    {
        if (_contentLoaded)
            return;
    
        _contentLoaded = true;
        global::Windows.UI.Xaml.Application.LoadComponent(this, 
                new global::System.Uri("ms-appx:///NullStylePage.xaml"), global::Windows.UI.Xaml.Controls.Primitives.ComponentResourceLocation.Application);
     
        FirstButtonStyle = (global::Windows.UI.Xaml.Style)this.FindName("FirstButtonStyle");
        SecondButtonStyle = (global::Windows.UI.Xaml.Style)this.FindName("SecondButtonStyle");
        MainPanel= (global::Windows.UI.Xaml.Controls.StackPanel)this.FindName("MainPanel");
        btn1 = (global::Windows.UI.Xaml.Controls.Button)this.FindName("btn1");
        btn2 = (global::Windows.UI.Xaml.Controls.Button)this.FindName("btn2");
    }
