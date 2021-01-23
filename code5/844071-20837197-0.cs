    public class MyGridView : DataGridView
    {
        protected override void InitLayout()
        {
            base.InitLayout();
            if (!DesignMode)
                BackgroundColor = Color.Red;
        }
    }
