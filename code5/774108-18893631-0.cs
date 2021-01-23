     public static bool TestMaxValue(this Type type, object compare)
        {
            var t = GetNullableType(type);
            var mv = t.GetMaxValue();
            bool ret = false;
            try
            {
                IComparable maxValue = Convert.ChangeType(mv, t) as IComparable;
                IComparable currentValue = Convert.ChangeType(compare, t) as IComparable;
                if (maxValue != null && currentValue != null)
                    ret = maxValue.CompareTo(currentValue) > 0;
            }
            catch (FormatException exception)
            {
                //handle is here
                ret = false;
            }
            return ret;
        }
