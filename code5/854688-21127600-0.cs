     [ProtoContract]
        public class StandaloneExtensible : IExtensible
        {
            [ProtoMember(1)]
            public int KnownField { get; set; }
    
            private byte[] buffer;
            Stream IExtensible.BeginAppend() {
                return Extensible.BeginAppend();
            }
            Stream IExtensible.BeginQuery() {
                return Extensible.BeginQuery(buffer);
            }
            void IExtensible.EndAppend(Stream stream, bool commit) {
                buffer = Extensible.EndAppend(buffer, stream, commit);
            }
            void IExtensible.EndQuery(Stream stream) {
                Extensible.EndQuery(stream);
            }
            int IExtensible.GetLength() {
                return Extensible.GetLength(buffer);
            }
        }
