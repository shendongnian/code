          /// <summary>
          /// Dispose all used resources.
          /// </summary>
          public void Dispose()
          {
              this.Dispose(true);
              GC.SuppressFinalize(this);
          }
            /// <summary>
            /// Dispose all used resources.
            /// </summary>
            /// <param name="disposing">Indicates the source call to dispose.</param>
            private void Dispose(bool disposing)
            {
                if (this.disposed)
                {
                    return;
                }
    
                if (disposing)
                {
                    ////Number of instance you want to dispose
                }
            }
