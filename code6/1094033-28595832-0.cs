    public class ModuleAViewModel : BindableBase, IConfirmNavigationRequest, INavigationAware, IRegionMemberLifetime
    {
     ...
            bool IRegionMemberLifetime.KeepAlive
        {
            get { return false; }
        }
    }
