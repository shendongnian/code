    using (var enu = things.GetEnumerator())
    {
        bool success;
        while (success = enu.MoveNext())
        {
            // Current value (always "valid"): enu.Current;
            if (something)
            {
                while (success = enu.MoveNext())
                {
                    // Current value (always "valid"): enu.Current;
                    if (enu.Current == someValue)
                    {
                        break;
                    }
                }
            }
            // Current value (check success before using it): enu.Current;
            if (success)
            {
                // Do more stuff on the new value of "thing"
            }
        }
    }
