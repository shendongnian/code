    static Reinterpret()
    {
        if (typeof(T) == typeof(int))
        {
            // Assign all the fields using lambda expressions for ints.
            // The actual assignment might be tricky, however - you may
            // need to resort to some ghastly casting, e.g.
            castDouble = (Func<double, T>)(Delegate)(Func<double, int>)
                x => *((double*)&value;
        }
        ....
    }
