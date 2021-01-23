    public class MouseClickTrigger : TriggerBase<UIElement>
    {
        private bool _isMouseDown;
        protected override void OnAttached()
        {
            this.AssociatedObject.MouseDown += this.AssociatedObject_MouseDown;
            this.AssociatedObject.MouseUp += this.AssociatedObject_MouseUp;
            this.AssociatedObject.MouseLeave += this.AssociatedObject_MouseLeave;
        }
        protected override void OnDetaching()
        {
            this.AssociatedObject.MouseDown -= this.AssociatedObject_MouseDown;
            this.AssociatedObject.MouseUp -= this.AssociatedObject_MouseUp;
            this.AssociatedObject.MouseLeave -= this.AssociatedObject_MouseLeave;
        }
        private void AssociatedObject_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this._isMouseDown = true;
        }
        private void AssociatedObject_MouseUp(object sender, MouseButtonEventArgs e)
        {
            bool fullClick = this._isMouseDown;
            this._isMouseDown = false;
            if (fullClick)
            {
                this.InvokeActions(e);
            }
        }
        private void AssociatedObject_MouseLeave(object sender, MouseEventArgs e)
        {
            this._isMouseDown = false;
        }
    }
