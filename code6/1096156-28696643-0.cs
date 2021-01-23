    public abstract class BaseAppender : AdoNetAppender
    {
        protected BaseAppender()
        {
            // Add common parameters, set connection strings etc
            // e.g.
            this.AddParameter(new AdoNetAppenderParameter
            {
                ParameterName = "@log_level",
                DbType = DbType.String,
                Size = 50,
                Layout = new RawLayoutConverter().ConvertFrom(new PatternLayout("%level")) as IRawLayout
            });
            // Then ask each subclass to add the extra parameters
            this.AddExtraParameters();
        }
        protected abstract void AddExtraParameters();
    }
    public class RuntimeAppender : BaseAppender
    {
        protected override void AddExtraParameters()
        {
            this.AddParameter(new AdoNetAppenderParameter
            {
                ParameterName = "@Method",
                DbType = DbType.String,
                Size = 255,
                Layout = new RawLayoutConverter().ConvertFrom(new PatternLayout("%method")) as IRawLayout
            });
        }
    }
    public class UnhandledExceptionAppender : BaseAppender
    {
        protected override void AddExtraParameters()
        {
            this.AddParameter(new AdoNetAppenderParameter
            {
                ParameterName = "@Method",
                DbType = DbType.String,
                Size = 255,
                Layout =
                    new RawLayoutConverter().ConvertFrom(new PatternLayout("%property{ExceptionMethod}")) as IRawLayout
            });
        }
    }
    public sealed class RuntimeLogger : Logger
    {
        public RuntimeLogger(string name)
            : base(name)
        {
            this.Appenders.Add(new RuntimeAppender());
            this.Level = Level.Error; // etc
        }
    }
    public sealed class UnhandledExceptionLogger : Logger
    {
        public UnhandledExceptionLogger(string name)
            : base(name)
        {
            this.Appenders.Add(new UnhandledExceptionAppender());
            this.Level = Level.Error; // etc
        }
    }
