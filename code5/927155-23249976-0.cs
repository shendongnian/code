    static class Extension
    {
        public static void SetFloat(this BitArray array, int index, bool value, float min, float max)
        {
            bool old = array.Get(index);
            array.Set(index, value);
            byte[] bytes = new byte[4];
            array.CopyTo(bytes, 0);
            float f = BitConverter.ToSingle(bytes, 0);
            if (f < min || f > max)
                array.Set(index, old);
        }
    }
