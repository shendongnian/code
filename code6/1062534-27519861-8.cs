    foreach (Control c1 in Controls)
    {
        foreach (Control c2 in Controls)
        {
            if (!c2.Equals(c1) 
            && c1.Bounds.IntersectsWith(c2.Bounds))
            {
                // c1 has touched c2
            }
        }
    }
