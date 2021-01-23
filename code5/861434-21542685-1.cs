    public enum UploadStatus
    {
    	/// <summary>
    	/// The upload has not started.
    	/// </summary>
    	NotStarted,
    
    	/// <summary>
    	/// The upload is initializing.
    	/// </summary>
    	Starting,
    
    	/// <summary>
    	/// Data is being uploaded.
    	/// </summary>
    	Uploading,
    
    	/// <summary>
    	/// Upload is being resumed.
    	/// </summary>
    	Resuming,
    
    	/// <summary>
    	/// The upload completed successfully.
    	/// </summary>
    	Completed,
    
    	/// <summary>
    	/// The upload failed.
    	/// </summary>
    	Failed
    };
