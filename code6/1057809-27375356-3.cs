    using System.Data.SqlTypes;
    using System.Text.RegularExpressions;
    using Microsoft.SqlServer.Server;
    namespace SqlExtensions
    {
        public static partial class UserDefinedFunctions
        {
            [SqlFunction]
            public static SqlString RegexGroup(SqlString input, SqlString pattern, SqlString name)
            {
                Regex regex = new Regex(pattern.Value, RegexOptions.Singleline);
                Match match = regex.Match(input.Value);
                return match.Success ? new SqlString(match.Groups[name.Value].Value) : SqlString.Null;
            }
        }
    }
