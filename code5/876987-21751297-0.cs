        int MyCount(string s1, string s2)
        {
            return s1.Count(c =>
                                {
                                    var i = s2.IndexOf(c);
                                    if (i >= 0)
                                    {
                                        s2 = s2.Remove(i, 1);
                                        return true;
                                    }
                                    return false;
                                });
        }
