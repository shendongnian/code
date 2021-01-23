    interface IUploader
    {
        void DoStuff();
    }
    interface IUploaderFactory
    {
        IUploader GetUploader(UploadOperation uploadOperation);
    }
    internal class UploadManager
    {
        internal UploadManager(IUploaderFactory uploaderFactory, UploadOperation uploadOperation)
        {
            var uploader = uploaderFactory.GetUploader(uploadOperation);
            
            //run different set of async tasks based on OperationType, 
            //using nested class Uploader
            uploader.DoStuff();
        }
    }
    
    internal class Uploader1 : IUploader
    {
        public void DoStuff()
        {
            ...
        }
    }
    internal class Uploader2 : IUploader
    {
        public void DoStuff()
        {
            ...
        }
    }
    internal class Uploader3 : IUploader
    {
        public void DoStuff()
        {
            ...
        }
    }
