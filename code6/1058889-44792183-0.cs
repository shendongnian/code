    public class GuiLabel : GuiElementBase, IDisposable
    {
        #region [ IDisposable Support ]
        private bool disposedValue = false; // To detect redundant calls
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // dispose managed state (managed objects).
                    LanguageManager.Instance.OnChangeLanguage -= HandleOnChangeLanguage;
                }
                disposedValue = true;
            }
        }
        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
        #endregion [ IDisposable Support ]
    }
