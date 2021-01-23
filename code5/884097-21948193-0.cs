    using Microsoft.Practices.Unity;
    using System.Threading;
    
    namespace Client.Engine
    {
        public sealed class Uploader : IUploader
        {
            public Uploader()
            {
            }
    
            public void PerformUpload(IUploadModule uploadModule, CancellationToken token, int batchSize)
            {
                token.ThrowIfCancellationRequested();
                uploadModule.Upload(token, batchSize);
            }
        }
    }
