    public partial class DefaultPage : Page
    {
        protected override void OnLoad(EventArgs e)
        {
            var val = Context.Items[key];
            base.OnLoad(e);
        }
    }
