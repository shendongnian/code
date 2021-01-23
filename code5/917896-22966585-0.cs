        /// <summary>
        /// A comparere class for sorting JsonObject lists on given key
        /// number values. Ascending.
        /// </summary>
        private class NumberComparerAsc : IComparer<JsonObject>
        {
            private string key;
            public NumberComparerAsc(string key)
            {
                this.key = key;
            }
            public int Compare(JsonObject x, JsonObject y)
            {
                int result = -1;
                IJsonValue xValue = null;
                IJsonValue yValue = null;
                x.TryGetValue(key, out xValue);
                y.TryGetValue(key, out yValue);
                if (xValue != null && yValue != null)
                {
                    // If they are both number do a compare.
                    if (xValue.ValueType == JsonValueType.Number && yValue.ValueType == JsonValueType.Number)
                    {
                        result = xValue.GetNumber().CompareTo(yValue.GetNumber());
                    }
                    else
                    {
                        // If x is a number, it is less they y.
                        if (xValue.ValueType == JsonValueType.Number)
                        {
                            result = -1;
                        }
                        // If y is a number, x is greater then y
                        else if (y.ValueType == JsonValueType.Number)
                        {
                            result = 1;
                        }
                        // If neither are a number they are equal
                        else
                        {
                            result = 0;
                        }
                    }
                }
                else
                {
                    if (xValue == null)
                    {
                        // x is less then y.
                        result = -1;
                    }
                    else if (yValue == null)
                    {
                        // x is greater then y.
                        result = 1;
                    }
                    else
                    {
                        // x and y are equal
                        result = 0;
                    }
                }
                return result;
            }
        }
