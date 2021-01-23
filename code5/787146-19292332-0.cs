    // this class only contains the db name and date
    class JournalInfo : IEquatable<JournalInfo>
    {
        private readonly string _dbName;
        public string DbName
        { get { return _dbName; } }
        private readonly DateTime _date;
        public DateTime Date
        { get { return _date; } }
        public JournalInfo(string db, DateTime date)
        {
            _dbName = db; _date = date;
        }
        public bool Equals(JournalInfo other)
        {
            if (object.ReferenceEquals(other, null)) 
                return false;
            else 
                return this.DbName == other.DbName && this.Date == other.Date;
        }
        public override bool Equals(object other)
        {
            return this.Equals(other as JournalInfo);
        }
        public override int GetHashCode()
        {
            var hash = 17;
            if (this.DbName != null) hash += this.DbName.GetHashCode();
            hash = hash * 31 + this.Date.GetHashCode();
            return hash;
        }
    }
