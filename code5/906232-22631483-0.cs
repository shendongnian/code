    public interface IImageConverter : IDisposable
    {
        string Name { get; }
        string DefaultSourceFileExtension { get; }
        string DefaultTargetFileExtension { get; }
        string[] SourceFileExtensions { get; }
        string[] TargetFileExtensions { get; }
        void Convert(ImageDetail image);
    }
