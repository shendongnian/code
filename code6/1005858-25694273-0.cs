        private void writeProperty(StringBuilder sb, string value, bool first, bool last)
        {
            if (! value.Contains('\"'))
            {
                if (!first)
                    sb.Append(',');
                sb.Append(value);
                if (last)
                    sb.AppendLine();
            }
            else
            {
                if (!first)
                    sb.Append(",\"");
                else
                    sb.Append('\"');
                sb.Append(value.Replace("\"", "\"\""));
                if (last)
                    sb.AppendLine("\"");
                else
                    sb.Append('\"');
            }
        }
        private void writeItem(StringBuilder sb, Test item)
        {
            writeProperty(sb, item.Id.ToString(), true, false);
            writeProperty(sb, item.Name, false, false);
            writeProperty(sb, item.CreatedDate, false, false);
            writeProperty(sb, item.DueDate, false, false);
            writeProperty(sb, item.ReferenceNo, false, false);
            writeProperty(sb, item.Parent, false, true);
        }
