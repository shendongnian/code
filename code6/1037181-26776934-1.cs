    <i:Interaction.Behaviors>
                    <icore:EventTriggerBehavior EventName="Holding">
                        <local:OpenFlyoutAction />
                    </icore:EventTriggerBehavior>
                </i:Interaction.Behaviors>
    public class OpenFlyoutAction : DependencyObject, IAction
        {
            public object Execute(object sender, object parameter)
            {
                // Show menu
                FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
    
                // sometimes the appbar is stuck behind the appbar, so hide the appbar
                (sender as FrameworkElement).GetFirstAncestorOfType<Page>().BottomAppBar.Visibility = Visibility.Collapsed;
    
                // show the appbar again when flyout is closed
                var flyout = FlyoutBase.GetAttachedFlyout((FrameworkElement)sender);
                EventHandler<object> showBar = null;
                showBar = delegate (object s, object e)
                {
                    (sender as FrameworkElement).GetFirstAncestorOfType<Page>().BottomAppBar.Visibility = Visibility.Visible;
                    // unsubscribe handler:
                    flyout.Closed -= showBar;
                };
                flyout.Closed += showBar;
    
                return null;
            }
        }
