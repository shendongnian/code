    // class for managing waiting cursor
    public class WaitCursor : IDisposable
    {
        private Cursor previousCursor;
        public WaitCursor()
        {
            this.previousCursor = Mouse.OverrideCursor;
            Mouse.OverrideCursor = Cursors.Wait;
        }
        #region IDisposable Members
        public void Dispose()
        {
            Mouse.OverrideCursor = this.previousCursor;
        }
        #endregion IDisposable Members
    }
