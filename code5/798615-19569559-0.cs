     /// <internalonly>
            void IDisposable.Dispose() {
                try
                {
                    Close();
                    OnDispose();
                }
                catch { }
            }
