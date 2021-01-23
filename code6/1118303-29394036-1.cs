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
