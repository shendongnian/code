    public interface ITabControlWithNotifications
    {
        void OnButtonClicked(...);
    }
    
    public sealed class TabControlWithNotifications : TabControl, ITabControlWithNotifications
    {
        public void OnButtonClicked(...)
        {
            ...
        }
    }
    
    public sealed class TabPageWithNotifications : TabPage
    {
        private readonly ITabControlWithNotifications parentTabControl;
        
        public TabPageWithNotifications(ITabControlWithNotifications tabControlWithNotifications)
        {
            this.parentTabControl = tabControlWithNotifications;
            this.InitialzeComponents();
        }
        
        ... ClickEventHandler(...)
        {
            this.parentTabControl.OnButtonClicked(...);
        }
    }
    
    public sealed class TabControlFactory
    {
        public void Build()
        {
            var parentTabControl = new TabControlWithNotifications();
            var tabPage1 = new TabPageWithNotifications(parentTabControl);
            var tabPage2 = new TabPageWithNotifications(parentTabControl);
            var tabPage3 = new TabPageWithNotifications(parentTabControl);
            parentTabControl.Controls.Add(tabPage1);
            parentTabControl.Controls.Add(tabPage2);
            parentTabControl.Controls.Add(tabPage3);
        }
    }
