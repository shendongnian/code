    using System;
    class Randomizer
    {
    public int[] M_Randomizer(int x)
    {
        bool b = false;
        if (x < -1)
        {
            b = true;
            x = -1 * x;
        }
        if(x == -1)
            x = 0;
        if (x < 2)
            return new int[x];
        int[] site;
        int k = new Random(Guid.NewGuid().GetHashCode()).Next() % 2;
        if (x == 2)
        {
            site = new int[2];
            site[0] = k;
            site[1] = 1 - site[0];
            return site;
        }
        else if (x == 3)
        {
            site = new int[3];
            site[0] = new Random(Guid.NewGuid().GetHashCode()).Next(0, 3);
            site[1] = (site[0] + k + 1) % 3;
            site[2] = 3 - (site[0] + site[1]);
            return site;
        }
        site = new int[x];
        int a = 0, m = 0, n = 0, tmp = 0;
        int[] p = M_Randomizer(3);
        int[] q;
        if (x % 3 == 0)
            q = M_Randomizer(x / 3);
        else
            q = M_Randomizer((x / 3) + 1);
        if (k == 0)
        {
            for (m = 0; m < q.Length; m++)
            {
                for (n = 0; n < p.Length && a < x; n++)
                {
                    tmp = (q[m] * 3) + p[n];
                    if (tmp < x)
                    {
                        site[a] = tmp;
                        a++;
                    }
                }
            }
        }
        else
        {
            while (n < p.Length)
            {
                while (a < x)
                {
                    tmp = (q[m] * 3) + p[n];
                    if (tmp < x)
                    {
                        site[a] = tmp;
                        a++;
                    }
                    m = m + k;
                    if (m >= q.Length)
                        break;
                }
                m = m % q.Length;
                n++;
            }
        }
        a = (new Random(Guid.NewGuid().GetHashCode()).Next() % 2) + 1;
        k = new Random(Guid.NewGuid().GetHashCode()).Next() % 10;
        if (k > 5)
            for (int i = a; i < k; i++)
                while (a < site.Length)
                {
                    if (k % (a + 1) == 0)
                    {
                        tmp = site[a - 1];
                        site[a - 1] = site[a];
                        site[a] = tmp;
                    }
                    a = a + 2;
                }
        k = new Random(Guid.NewGuid().GetHashCode()).Next() % 10;
        if (k > 5)
        {
            n = x / 2;
            k = 0;
            if (x % 2 != 0)
                k = (new Random(Guid.NewGuid().GetHashCode()).Next() % 2);
            p = new int[n + k];
            m = (x - n) - k;
            for (a = 0; m < x; a++, m++)
                p[a] = site[m];
            m = n + k;
            for (a = (x - m) - 1; a >= 0; a--, m++)
                site[m] = site[a];
            for (a = 0; a < p.Length; a++)
                site[a] = p[a];
        }
        int[] site2;
        int[] site3 = new int[x];
        if (b)
            return site;
        else
            site2 = M_Randomizer(-1 * x);
        for (a = 0; a < site.Length; a++)
            site3[site2[a]] = site[a];
        return site3;
    }
    public int[] M_Randomizer(int x, int start)
    {
        int[] dm = M_Randomizer(x);
        for(int a = 0; a < x; a++)
            dm[a] = dm[a] + start;
        return dm;
    }
    }
