    public interface ITreePlugin {}
    public interface ICanvasPlugin {}
    
    [Export(typeof(ICanvasPlugin)]
    public class CanvasPlugin : ICanvasPlugin 
    {
        // treePlugin must be imported
        [ImportingConstructor]
        public CanvasPlugin(ITreePlugin treePlugin) {}
    
        // ...
    }
