    public static DateTime? TryGetDate(this string dateString, string format = null)
        {
            DateTime dt;
            bool success = format == null ? DateTime.TryParse(dateString, out dt) : DateTime.TryParseExact(dateString, format, null, DateTimeStyles.None, out dt);
            return success ? dt : (DateTime?)null;
        }
