    public class ButtonWithOverture : Button
    {
        public Action Overture { get; set;}        
        protected override void OnClick(EventArgs e)
        {
            if (Overture != null)
                Overture();
            base.OnClick(e);
        }
    }
