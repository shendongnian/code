    public interface IApplicationInfrastructureProvider : IInfrastructureProvider
    {
        ICollection<ViewModel> RibbonTabs { get; }
        ICollection<ViewModel> ApplicationMenuItems { get; }
        ICollection<ViewModel> QuickAccessToolbarItems { get; }
        ICollection<ViewModel> StatusBarItems { get; }
    }
