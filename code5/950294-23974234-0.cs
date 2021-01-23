    driversList.Sort(
        delegate(Driver d1, Driver d2)
        {
            if (d1.championshipPoints == d2.championshipPoints)
            {
                return d1.name.CompareTo(d2.name);
            }
            return d1.championshipPoints.CompareTo(d2.championshipPoints);
        }
    );
