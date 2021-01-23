    public bool Equality(byte[] a1, byte[] b1)
    {
        // If not same length, done
        if (a1.Length != b1.Length)
        {
            return false;
        }
        // If they are the same object, done
        if (object.ReferenceEquals(a1,b1))
        {
            return true;
        }
        // Loop all values and compare
        for (int i = 0; i < a1.Length; i++)
        {
            if (a1[i] != b1[i])
            {
                return false;
            }
        }
        // If we got here, equal
        return true;
    }
