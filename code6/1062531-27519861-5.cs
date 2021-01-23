    // if your first control is specified you can use the following code
    foreach (Control c2 in Controls)
    {
        if (!c2.Equals(c1) && c2 is Button /* if you want it to be just buttons */
        && c1.DisplayRectangle.IntersectsWith(c2.DisplayRectangle))
        {
            // c1 has touched c2
        }
    }
    
