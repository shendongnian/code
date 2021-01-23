    namespace XXX.YYY.ZZZMyExternalServiceOrWhatever
    {
        /// <summary>
        /// Partial definition of MyExternalServiceClient.
        /// </summary>
        public partial class MyExternalServiceClient : IDisposable
        {
            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            void IDisposable.Dispose()
            {
                bool success = false;
                try
                {
                    if (this.State != CommunicationState.Faulted)
                    {
                        this.Close();
                        success = true;
                    }
                }
                finally
                {
                    if (!success)
                    {
                        this.Abort();
                    }
                }
            }
        }
    }
