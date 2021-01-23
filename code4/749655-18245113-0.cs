    public class TrackPartRecord : ContentPartRecord
    {
        public virtual IList<TrackInformationRecord> Tracks { get; set; }
    }
    public class TrackInformationRecord
    {
        // Own properties
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual bool IsDeleted { get; set; }
        // Relations properties
        public virtual TrackPartRecord TrackPartRecord { get; set; }
    }
