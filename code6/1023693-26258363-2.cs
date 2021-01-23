	/// <summary>
	/// Maps a <see cref="System.DateTime" /> Property to an DateTime column that only stores the 
	/// Hours, Minutes, and Seconds of the DateTime as significant.
	/// Also you have for <see cref="DbType.Time"/> handling, the NHibernate Type <see cref="TimeAsTimeSpanType"/>,
	/// the which maps to a <see cref="TimeSpan"/>.
	/// </summary>
	/// <remarks>
	/// <para>
	/// This defaults the Date to "1753-01-01" - that should not matter because
	/// using this Type indicates that you don't care about the Date portion of the DateTime.
	/// </para>
	/// <para>
	/// A more appropriate choice to store the duration/time is the <see cref="TimeSpanType"/>.
	/// The underlying <see cref="DbType.Time"/> tends to be handled differently by different
	/// DataProviders.
	/// </para>
	/// </remarks>
	[Serializable]
	public class TimeType : PrimitiveType, IIdentifierType, ILiteralType
