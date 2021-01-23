    public class ComLobConnection
    {
        public virtual Guid ComID { get; set; }
        public virtual Guid LobID { get; set; }
    }
    public class ComLobConnectionMap : ClassMap<ComLobConnection>
    {
        public ComLobConnectionMap()
        {
            Table("LOB_COM");
            Id();
            Map(x => x.ComID,"COM_ID");
            Map(x => x.LobID,"LOB_ID");
        }
    }
