            var minDate = DateTime.MinValue;
            var maxDate = DateTime.MaxValue;
            foreach (var item in data)
            {
                switch (item.name)
                {
                    case CustomFieldConstants.MinDate:
                        DateTime.TryParse((string)item.value, out minDate);
                        break;
                    case CustomFieldConstants.MaxDate:
                        DateTime.TryParse((string)item.value, out maxDate);
                        break;
                }
            }
