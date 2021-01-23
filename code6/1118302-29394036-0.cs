    using System;
    using System.Data;
    using global::NHibernate.Engine;
    using global::NHibernate.Type;
    using Foundation.Core;
    /// <summary>
    /// This type save the <see cref="DateTime"/> to the database. You need to save the <see cref="DateTime"/> in UTC (<see cref="DateTimeKind.Utc"/>).
    /// When you load the <see cref="DateTime"/>, then time is in UTC.
    /// </summary>
    /// <seealso cref="http://stackoverflow.com/questions/29352719/save-and-load-utc-datetime-with-nhibernate"/>
    public class UtcTimestampType : TimestampType
    {
        public override string Name
        {
            get { return "UtcTimestamp"; }
        }
        /// <summary>
        /// Sets the value of this Type in the IDbCommand.
        /// </summary>
        /// <param name="st">The IDbCommand to add the Type's value to.</param>
        /// <param name="value">The value of the Type.</param>
        /// <param name="index">The index of the IDataParameter in the IDbCommand.</param>
        /// <remarks>
        /// No null values will be written to the IDbCommand for this Type.
        /// The <see cref="DateTime.Kind"/> must be <see cref="DateTimeKind.Utc"/>.
        /// </remarks>
        public override void Set(IDbCommand st, object value, int index)
        {
            DateTime dateTime = (DateTime)((value is DateTime) ? value : DateTime.UtcNow);
            Check.IsValid(() => dateTime, dateTime, time => time.Kind == DateTimeKind.Utc, "You need to save the date time in the utc format.");
            // Change the kind to unspecified, because when we load the datetime we have wrong values with kind utc.
            ((IDataParameter)st.Parameters[index]).Value = DateTime.SpecifyKind(dateTime, DateTimeKind.Unspecified);
        }
        public override object Get(IDataReader rs, int index)
        {
            return ChangeDateTimeKindToUtc(base.Get(rs, index));
        }
        public override object Get(IDataReader rs, string name)
        {
            return ChangeDateTimeKindToUtc(base.Get(rs, name));
        }
        public override object FromStringValue(string xml)
        {
            return ChangeDateTimeKindToUtc(base.FromStringValue(xml));
        }
        public override object Seed(ISessionImplementor session)
        {
            if (session == null)
            {
                return DateTime.UtcNow;
            }
            return Round(DateTime.UtcNow, session.Factory.Dialect.TimestampResolutionInTicks);
        }
        private DateTime ChangeDateTimeKindToUtc(object value)
        {
            DateTime dateTime = (DateTime)value;
            return new DateTime(dateTime.Ticks, DateTimeKind.Utc);
        }
    }
