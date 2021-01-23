    public interface IJustWantTheseColumnsInterface
    {
        ...
        IPhone Phone { get; set; }
        ...
    }
    public class SameTableMap : ClassMap<SameTable>
    {
        public SameTableMap()
        {
            ...
            Reference(x => x.Phone, "PHONE_ID").Class(typeof(Phone));
            ...
        }
    }
