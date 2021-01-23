    public long? TOTALMEMORY { get; set; }
    [Display(Name="RAM (in GB)")]
    public double? TotalMemoryGB 
    {
       get 
       {
           // The 1024.0 serves to force double division, instead of integer
           return TOTALMEMORY / 1024.0 / 1024.0 / 1024.0;
       }
       set 
       {
           TOTALMEMORY = (long) (value * 1024 * 1024 * 1024);
       } 
    }
