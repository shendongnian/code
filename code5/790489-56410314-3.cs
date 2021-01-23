    public class ClientSessionOptions
    {
        public bool? CausalConsistency { get; set; }
        public TransactionOptions DefaultTransactionOptions { get; set; }
    }
    public class TransactionOptions
    {
        public ReadConcern ReadConcern { get; };
        public ReadPreference ReadPreference { get; };
        public WriteConcern WriteConcern { get; };
    
        public TransactionOptions(
            Optional<ReadConcern> readConcern = default(Optional<ReadConcern>),
            Optional<ReadPreference> readPreference = default(Optional<ReadPreference>),
            Optional<WriteConcern> writeConcern = default(Optional<WriteConcern>));
    
        public TransactionOptions With(
            Optional<ReadConcern> readConcern = default(Optional<ReadConcern>),
            Optional<ReadPreference> readPreference = default(Optional<ReadPreference>),
            Optional<WriteConcern> writeConcern = default(Optional<WriteConcern>))
    }
