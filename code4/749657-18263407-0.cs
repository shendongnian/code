    public class TrackInformationRecordOverride
        : IAutoMappingOverride<TrackInformationRecord>
    {
        public void Override(AutoMapping<TrackInformationRecord> mapping)
        {
            mapping.HasMany(x => x.Sessions)
                .KeyColumn("TrackId"); // ... assuming TrackId is the column you wanted.
        }
    }
