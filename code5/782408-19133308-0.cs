    public abstract class Graph
    {
       #region Private Members
       private string m_baseDir = "";
       private string m_imageFile = m_graphName + Utils.ImageExtension;
       #endregion Private Members
       #region Properties
       public string BaseDir
       {
           set { m_baseDir = value; }
       }
       public string GraphName
       {
           get { return m_graphName; }
       }
    
       public abstract string ImageFile { get; }
       #endregion Properties
       #region Constructor
       public HandTrackingGraphs(string baseDir)
       {
           m_baseDir = baseDir;
       }
       #endregion Constructor
    }
    public class GraphOne : Graph
    {
        public override string ImageFile { get { return "GraphOne"; } }
    }
    public class GraphTwo : Graph
    {
        public override string ImageFile { get { return "GraphTwo"; } }
    }
    public class GraphThree : Graph
    {
        public override string ImageFile { get { return "GraphThree"; } }
    }
