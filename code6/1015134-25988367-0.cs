    public interface IHistoricalEntity
    {
        int ID { get; set; }
        int ENTITY_ID { get; set; }
        DateTime CREATE_DATE { get; set; }
        DateTime DELETE_DATE { get; set; }
        int CREATOR { get; set; }
    }
