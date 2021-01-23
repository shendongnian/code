    public partial class DefaultPage : Page
    {
        protected override void OnLoad(EventArgs e)
        {
            var loadStartTime = (DateTime)Context.Items["loadstarttime"];
            base.OnLoad(e);
        }
    }
