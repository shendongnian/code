    using System;
    static class Program {
        public static DateTime? SetUtc(object value) {
            return new DateTime?(DateTime.SpecifyKind(((DateTime?)value).Value, DateTimeKind.Utc));
        }
    };
