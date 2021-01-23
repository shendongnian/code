    using(E e = sequence.GetEnumerator())
    {
        while (e.MoveNext())
        {
            XmlDocument v = (XmlDocument)e.Current;
            // loop body
        }
    }
