    public class OpenPopupWindowAction : TriggerAction<FrameworkElement>
    {     
        protected override void Invoke(object parameter)
        {           
            var popup = (ChildWindow)ServiceLocator.Current.GetInstance<IPopupDialogWindow>();
            popup.Owner = PlacementTarget ?? (Window)ServiceLocator.Current.GetInstance<IShell>();
            popup.DialogResultCommand = PopupDailogResultCommand;
            popup.Show();                      
        }
    
        public Window PlacementTarget
        {
            get { return (Window)GetValue(PlacementTargetProperty); }
            set { SetValue(PlacementTargetProperty, value); }
        }       
        
        public static readonly DependencyProperty PlacementTargetProperty =
            DependencyProperty.Register("PlacementTarget", typeof(Window), typeof(OpenPopupWindowAction), new PropertyMetadata(null));
        public ICommand PopupDailogResultCommand    
        {
            get { return (ICommand)GetValue(PopupDailogResultCommandProperty); }
            set { SetValue(PopupDailogResultCommandProperty, value); }
        }
        public static readonly DependencyProperty PopupDailogResultCommandProperty =
            DependencyProperty.Register("PopupDailogResultCommand", typeof(ICommand), typeof(OpenPopupWindowAction), new PropertyMetadata(null));        
    }
