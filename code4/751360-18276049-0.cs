    public interface ISited {
        int SiteId {get; set; }
    }
    
    class MyDao : ISited { .. }
    class MyEntity : ISited { .. }
