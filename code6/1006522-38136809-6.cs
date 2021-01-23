    namespace UWA.MenuFlyout.Core
    {
        using Microsoft.Xaml.Interactivity;
        using Windows.UI.Xaml;
        using Windows.UI.Xaml.Controls.Primitives;
    
        public class OpenMenuFlyoutAction : DependencyObject, IAction
        {
            public object Execute(object sender, object parameter)
            {
                var frameworkElement = sender as FrameworkElement;
                var flyoutBase = FlyoutBase.GetAttachedFlyout(frameworkElement);
                flyoutBase.ShowAt(frameworkElement);
    
                return null;
            }
        }
    }
