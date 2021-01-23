    [ProtoContract]
    public class Entity
    {
        private bool _idInitialized = false;
        private Guid _id;
        public Guid id
        {
            get
            {
                if ( !_idInitialized )
                {
                    _id = new Guid( idBytes );
                    _idInitialized = true;
                }
                return _id;
            }
        }
        [ProtoMember( 1, IsRequired = true )]
        public byte[] idBytes;
        [ProtoMember( 2, IsRequired = true )]
        public String name;
        // For application code, sending side
        public Entity( Guid theId, String theName )
        {
            if ( String.IsNullOrEmpty( theName ) )
            {
                throw new ArgumentNullException( "theName" );
            }
            idBytes = theId.ToByteArray();
            _id = theId;
            _idInitialized = true;
            name = theName;
        }
        // For protobuf-net, receiving side
        public Entity() { }
    }
