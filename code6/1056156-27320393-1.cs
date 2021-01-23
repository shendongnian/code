        public static int CompareObjects(object valueX, object valueY)
        {
            IComparable myValueX = valueX as IComparable;
            IComparable myValueY = valueY as IComparable;
            if (myValueX == null)
            {
                if (myValueY == null)
                    return 0;
                return -1;
            }
            if (myValueY == null)
                return 1;
            Type typeX = valueX.GetType();
            Type typeY = valueY.GetType();
            if (!typeX.Equals(typeY))
            {
                int ret = typeX.GetHashCode().CompareTo(typeY.GetHashCode());
                if (ret != 0) return ret;
                return string.CompareOrdinal(typeX.Name, typeY.Name);
            }
            return myValueX.CompareTo(myValueY);
        }
