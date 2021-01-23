    else if (!newM2.Assigned)
    {
        var m2 = m1.M2s.SingleOrDefault(c => c.Id == newM2.Id);
        if (m2 != null)
        {
            m1.M2s.Remove(m2);
        }
    }
