    public partial class DefaultPage : Page
    {
        protected override void OnUnload(EventArgs e)
        {
            Context.Items["PageUnloaded"] = true;
            base.OnUnload(e);
        }
    } 
