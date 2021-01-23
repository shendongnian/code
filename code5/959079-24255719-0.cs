    public class Position
    {
        public double lat, lon, elev;
        public Position(IEnumerable<double> coords)
        {
            if (coords == null)
            {
                throw new ArgumentException();
            }
            using (var enumerator = coords.GetEnumerator())
            {
                if (enumerator != null && enumerator.MoveNext())
                {
                    this.lat = enumerator.Current;
                    if (enumerator.MoveNext())
                    {
                        this.lon = enumerator.Current;
                        if (enumerator.MoveNext())
                        {
                            this.elev = enumerator.Current;
                            /*
                            if (enumerator.MoveNext())
                            {
                                // What to do here??  throw an exception?
                                throw new ArgumentException();
                            }*/
                            return;
                        }
                    }
                }
            }
            throw new ArgumentException();
        }
    }
