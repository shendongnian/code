    public class MyReader : DbDataReader
    {
        SqlDataReader _reader;
        public Reader(DbDataReader reader)
        {
            _reader = (SqlDataReader)reader;
        }
        public override string GetString(int ordinal)
        {
            return _reader.GetString(ordinal).Trim();
        }
...
    using(var reader = new MyReader(command.ExecuteReader()))
    {
