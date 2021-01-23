    internal static int[] Locate(this byte[] self, byte[] candidate)
    {
        if (IsEmptyLocate(self, candidate))
            return null;
        var list = new List<int>();
        for (int i = 0; i < self.Length; i++)
        {
            if (!IsMatch(self, i, candidate))
                continue;
            list.Add(i);
        }
        return list.Count == 0 ? null : list.ToArray();
    }
    static bool IsMatch(byte[] array, int position, byte[] candidate)
    {
        if (candidate.Length > (array.Length - position))
            return false;
        for (int i = 0; i < candidate.Length; i++)
            if (array[position + i] != candidate[i])
                return false;
        return true;
    }
    static bool IsEmptyLocate(byte[] array, byte[] candidate)
    {
        return array == null
            || candidate == null
            || array.Length == 0
            || candidate.Length == 0
            || candidate.Length > array.Length;
    }
    internal static byte[] trimArray(byte[] man, byte[] remove)
    {
        try
        {
            int seekp = Program.Locate(man, remove)[0];
            if (seekp > 0)
            {
                byte[] pr = new byte[seekp];
                Array.Copy(man, 0, pr, 0, seekp);
                byte[] aa = new byte[man.Length - seekp];
                Array.Copy(man, seekp, aa, 0, man.Length - seekp);
                man = aa;
                byte[] hm = new byte[man.Length - remove.Length];
                Array.Copy(man, seekp + remove.Length, hm, 0, hm.Length);
                return hm;
            }
            byte[] hm = new byte[man.Length - remove.Length];
            Array.Copy(man, seekp + remove.Length, hm, 0, hm.Length);
            return hm;
        }
        catch (Exception ee)
        {
            return new byte[] { };
        }
    }
