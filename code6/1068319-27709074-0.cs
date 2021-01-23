        public static bool SetValue(this List<T> sequence, int newValue, int oldValue)
        {
            var collection = sequence;
            if (collection == null
                || (Math.Min(newValue, oldValue) <= -1)
                || (Math.Max(newValue, oldValue) >= collection.Count()))
            {
                return false;
            }
            if (newValue != oldValue)
            {
                var value = collection[oldValue];
                collection.RemoveAt(oldValue);
                collection.Insert(newValue + (newValue > oldValue ? 1 : 0), value);
            }
            return true;
        }
