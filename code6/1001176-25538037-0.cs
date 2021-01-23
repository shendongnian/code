    public class Artifact
    {
    	public string DisplayPath { get;  set; }
    	public string FileName { get; set; }
    	public string RelativePath { get; set; }
    }
    
    public class ArtifactContainer
    {
    	public IEnumerable<Artifact> Artifacts { get; set; }
    }
