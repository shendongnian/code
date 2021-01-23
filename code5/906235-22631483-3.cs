    public sealed class PluginManager : IPluginManager
    {
        private readonly IEnumerable<IImageConverter> converters;
        public PluginManager(IEnumerable<IImageConverter> converters) {
            this.converters = converters;
        }
        public IList<IImageConverter> List() {
            return this.converters.ToList();
        }
        public IList<IImageConverter> FindBySource(string extension) {
            IEnumerable<IImageConverter> converters = this.converters
                .Where(x =>
                    x.SourceFileExtensions.Contains(extension));
            return converters.ToList();
        }
        public IList<IImageConverter> FindByTarget(string extension) {
            IEnumerable<IImageConverter> converters = this.converters
                .Where(x =>
                    x.TargetFileExtensions.Contains(extension));
            return converters.ToList();
        }
        public IList<IImageConverter> Find(
            string sourceFileExtension, 
            string targetFileExtension)
        {
            IEnumerable<IImageConverter> converter = this.converters
                .Where(x =>
                    x.SourceFileExtensions.Contains(sourceFileExtension) &&
                    x.TargetFileExtensions.Contains(targetFileExtension));
            return converter.ToList();
        }
        public IImageConverter Find(string name) {
            IEnumerable<IImageConverter> converter = this.converters
                .Where(x => x.Name == name);
            return converter.SingleOrDefault();
        }
    }
