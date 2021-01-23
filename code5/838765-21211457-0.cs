    public class CustomApplicationBarIconButton : ApplicationBarIconButton
    {
        public new event EventHandler Click;
        public void RaiseClick()
        {
            if (Click != null)
                Click(this, EventArgs.Empty);
        }
    }
