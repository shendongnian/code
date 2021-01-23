    /// <summary>
    /// Represents a unique journal info.
    /// This class implements value-type comparison semantics.
    /// </summary>
    class JournalInfo : IEquatable<JournalInfo>
    {
        private readonly string _dbName;
        /// <summary>Gets the database name.</summary>
        public string DbName
        { get { return _dbName; } }
        private readonly DateTime _date;
        /// <summary>Gets the date.</summary>
        public DateTime Date
        { get { return _date; } }
        /// <summary>Initializes a new instance of the <see cref="JournalInfo"/> class.</summary>
        public JournalInfo(string db, DateTime date)
        {
            _dbName = db; _date = date;
        }
        #region Equals overrides to ensure value-type comparison semantics
        // a lot of plumbing needs to be done here to solve a simple task,
        // but it must be done to ensure consistency in all cases
        /// <summary>Determines whether the specified <see cref="JournalInfo" /> is equal to this instance.</summary>
        public bool Equals(JournalInfo other)
        {
            if (object.ReferenceEquals(other, null)) 
                return false;
            else 
                return this.DbName == other.DbName && this.Date == other.Date;
        }
        /// <summary>Determines whether the specified <see cref="System.Object" /> is equal to this instance.</summary>
        public override bool Equals(object other)
        {
            return this.Equals(other as JournalInfo);
        }
        /// <summary>Returns a hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</summary>
        public override int GetHashCode()
        {
            var hash = 17;
            if (this.DbName != null) hash += this.DbName.GetHashCode();
            hash = hash * 31 + this.Date.GetHashCode();
            return hash;
        }
        public static bool operator ==(JournalInfo a, JournalInfo b)
        {
            if (object.ReferenceEquals(a, null))
                return object.ReferenceEquals(b, null);
            return ((JournalInfo)a).Equals(b);
        }
        public static bool operator !=(JournalInfo a, JournalInfo b)
        {
            if (object.ReferenceEquals(a, null))
                return !object.ReferenceEquals(b, null);
            
            return !((JournalInfo)a).Equals(b);
        }
        #endregion
    }
