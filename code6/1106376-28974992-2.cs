    public class UploadJob
    {
    	public string Group { get; protected set; }
    	
    	public string Name { get; protected set; }
    	
    	public string Message { get; protected set; }
    	
    	public string Caption { get; protected set; }
    	
    	public string Link { get; protected set; }
    	
    	public string Description { get; protected set; }
    	
    	public string Picture { get; protected set; }
    	
    	public UploadJob(string group,
                         string name,
                         string message,
                         string caption,
                         string link,
                         string description,
                         string picture)
        {
            Group = group;
            Name = name;
            Message = message;
            Caption = caption;
            Link = link;
            Description = description;
            Picture = picture;
        }
    }
