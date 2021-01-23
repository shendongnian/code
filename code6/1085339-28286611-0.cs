    public class TextProcessingFilter : PluginBase, ITextProcessor
    {
        public void Register(IFeatureRepository repos)
        {
            repos.Get<ITextEditor>().Subscribe(this);
        }
        void ITextProcessor.Process(TextEditorContext ctx)
        {
        }
    }
