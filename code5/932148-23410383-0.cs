            var intValues = values.Where(v => v.Keys.Contains("id")).Select(v =>
            {
                int val;
                if (int.TryParse(v["id"].ToString(), out val))
                {
                    return val;
                }
                return int.MinValue;
            }).Where(v => v > int.MinValue);
            int? maxIdValue = null;
            if (intValues.Any())
                maxIdValue = intValues.Max();
