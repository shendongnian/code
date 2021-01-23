	/// <summary>
    /// Maps a <see cref="System.TimeSpan" /> Property to an 
    /// <see cref="DbType.Time" /> column
    /// This is an extra way to map a <see cref="DbType.Time"/>. You already have 
    /// <see cref="TimeType"/>
    /// but mapping against a <see cref="DateTime"/>.
    /// </summary>
    [Serializable]
    public class TimeAsTimeSpanType : PrimitiveType, IVersionType
