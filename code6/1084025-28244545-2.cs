            var jsonString = query.Aggregate(new StringBuilder("["), (sb, pair) =>
            {
                if (sb.Length > 1)
                    sb.AppendLine(",");
                return sb.AppendFormat("[gd({0}, {1}, {2}), {3}]", pair.LogDate.Year, pair.LogDate.Month, pair.LogDate.Day, pair.Count);
            }).Append("]").ToString();
            Debug.WriteLine(jsonString);
