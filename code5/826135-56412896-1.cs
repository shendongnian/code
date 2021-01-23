    public bool? IsActive { get; set; }
    
    public string IsActiveDescriptor => IsActive.HasValue && IsActive ? "Yes" : "NO";
            
    
