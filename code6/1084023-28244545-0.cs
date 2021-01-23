            var jsonString = query.Aggregate(new StringBuilder("["), (sb, pair) =>
            {
                if (sb.Length > 1)
                    sb.AppendLine(",");
                return sb.Append("[gd(").Append(pair.LogDate.Year).Append(", ").Append(pair.LogDate.Month).Append(", ").Append(pair.LogDate.Day).Append("), ").Append(pair.Count).Append("]");
            }).Append("]").ToString();
            Debug.WriteLine(jsonString);
