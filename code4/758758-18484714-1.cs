    //sealed - can't be a true singleton if someone can inherit from and create it via a back door
    public sealed class FileShareAccessFactory : IFileShareAccessFactory
    {
        // hide constructor
        private FileShareAccessFactory(){}
        // provide access via public static field
        public static readonly IFileShareAccess Instance = new FileShareAccessFactory();
    }
