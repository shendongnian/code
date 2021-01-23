    foreach (Control c1 in Controls)
    {
        foreach (Control c2 in Controls)
        {
            if (c1.DisplayRectangle.IntersectsWith(c2.DisplayRectangle))
            {
                // c1 has touched c2
            }
        }
    }
