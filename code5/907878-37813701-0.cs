    using System;
    using Windows.ApplicationModel.Activation;
    using Windows.UI;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media;
    namespace MyApp
    {
        class Program
        {
            public static void Main (string[] args)
            {
        	    Application.Start((p) => new MyApp());
            }
        }
        class MyApp : Windows.UI.Xaml.Application
        {
            public MyApp(){}
            protected override void OnLaunched(LaunchActivatedEventArgs args)
            {
                var layoutRoot = new Grid() { Background = new SolidColorBrush(Colors.Blue) };
                layoutRoot.Children.Add(new Button() { Content = "Hello!" });
                Window.Current.Content = layoutRoot;
                Window.Current.Activate();
            }
        }
    }
