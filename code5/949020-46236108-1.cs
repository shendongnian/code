     private void ResolveStatusName(string statusName, out string statusCode = "")
        {
            if (statusName != "Any")
            {
                statusCode = statusName.Length > 1
                    ? statusName.Substring(0, 1)
                    : statusName;
            }
        }
