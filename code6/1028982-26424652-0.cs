    [ProtoContract]
    public class Entity
    {
        private Guid _id;
        public Guid id
        {
            get
            {
                if ( _id.Equals( Guid.Empty ) )
                {
                    _id = new Guid( idBytes );
                }
                return _id;
            }
        }
        [ProtoMember( 1, IsRequired = true )]
        public byte[] idBytes;
        [ProtoMember( 2, IsRequired = true )]
        public String name;
        public Entity( Guid theId, String theName )
        {
            if ( String.IsNullOrEmpty( theName ) )
            {
                throw new ArgumentNullException( "theName" );
            }
            idBytes = theId.ToByteArray();
            name = theName;
        }
    }
