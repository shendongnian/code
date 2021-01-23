    public class SomeDbContext:DbContext
    {
        private readonly IFileRepository _fileRepository;
        public SomeDbContext(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }
        ...
    }
