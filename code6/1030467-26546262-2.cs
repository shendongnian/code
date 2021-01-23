    public class WPFAddIn_ViewToContractAddInSideAdapter : ContractBase, IWPFAddInContract
    {
        public INativeHandleContract GetAddInUI()
        {
            FrameworkElement fe = this.wpfAddInView as FrameworkElement; // return instance directly instead of creating new one by wpfAddInView.GetAddInUI();
            INativeHandleContract inhc = FrameworkElementAdapters.ViewToContractAdapter(fe);
            return inhc;
        }
    }
