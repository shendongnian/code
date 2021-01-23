    DispatchCommandResult(new PluginResult(PluginResult.Status.OK, "imaged passed back from   camera.xaml should go here"));
    Deployment.Current.Dispatcher.BeginInvoke(() =>
    {
        root = Application.Current.RootVisual as PhoneApplicationFrame;
        root.GoBack();
    });
