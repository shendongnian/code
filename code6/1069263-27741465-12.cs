    public partial class DefaultPage : Page
    {
        protected override void OnUnload(EventArgs e)
        {
            Context.Items["AfterPageUnloaded"] = true;
            base.OnUnload(e);
        }
    } 
