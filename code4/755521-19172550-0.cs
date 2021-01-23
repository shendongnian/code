    class CheckPolygon2
    {
        // internal supporting classes
        class endpointEntry
        {
            public double XValue;
            public bool isHi;
            public Line2D line;
            public double hi;
            public double lo;
            public endpointEntry fLink;
            public endpointEntry bLink;
            public override string ToString()
            {
                return (isHi ? "Hi" : "Lo") + " X " + XValue.ToString() + " of Line " + line.ToString();
            }
        }
        class endpointSorter : IComparer<endpointEntry>
        {
            public int Compare(endpointEntry c1, endpointEntry c2)
            {
                // sort values on XValue, descending
                if (c1.XValue > c2.XValue) { return -1; }
                else if (c1.XValue < c2.XValue) { return 1; }
                else // must be equal, make sure hi's sort before lo's
                    if (c1.isHi && !c2.isHi) { return -1; }
                    else if (!c1.isHi && c2.isHi) { return 1; }
                    else { return 0; }
            }
        }
        public bool CheckForCrossing(List<Line2D> lines)
        {
            List<endpointEntry> pts = new List<endpointEntry>(2 * lines.Count);
            // Make endpoint objects from the lines so that we can sort all of the
            // lines endpoints.
            foreach (Line2D lin in lines)
            {
                // make the endpoint objects for this line
                endpointEntry hi, lo;
                if (lin.P1.X < lin.P2.X)
                {
                    hi = new endpointEntry() { XValue = lin.P2.X, isHi = true, line = lin, hi = lin.P2.X, lo = lin.P1.X };
                    lo = new endpointEntry() { XValue = lin.P1.X, isHi = false, line = lin, hi = lin.P1.X, lo = lin.P2.X };
                }
                else
                {
                    hi = new endpointEntry() { XValue = lin.P1.X, isHi = true, line = lin, hi = lin.P1.X, lo = lin.P2.X };
                    lo = new endpointEntry() { XValue = lin.P2.X, isHi = false, line = lin, hi = lin.P2.X, lo = lin.P1.X };
                }
                // add them to the sort-list
                pts.Add(hi);
                pts.Add(lo);
            }
            // sort the list
            pts.Sort(new endpointSorter());
            // sort the endpoint forward and backward links
            endpointEntry prev = null;
            foreach (endpointEntry pt in pts)
            {
                if (prev != null)
                {
                    pt.bLink = prev;
                    prev.fLink = pt;
                }
                prev = pt;
            }
            // NOW, we are ready to look for intersecting lines
            foreach (endpointEntry pt in pts)
            {
                // for every Hi endpoint ...
                if (pt.isHi)
                {
                    Debug.Print("");
                    Debug.Print("Scanning down from endpoint " + pt.ToString() + " TO " + pt.lo.ToString());
                    // check every other line whose X-range is either wholly 
                    // contained within our own, or that overlaps the high 
                    // part of ours.  The other two cases of overlap (overlaps 
                    // our low end, or wholly contains us) is covered by hi 
                    // points above that scan down to check us.
                    // scan down for each lo-endpoint below us checking each's 
                    // line for intersection until we pass our own lo-X value
                    for (endpointEntry pLo = pt.fLink; (pLo != null) && (pLo.XValue >= pt.lo); pLo = pLo.fLink)
                    {
                        // is this a lo-endpoint?
                        if (!pLo.isHi)
                        {
                            Debug.Print("  call on endpoint " + pLo.ToString());
                            // check its line for intersection
                            if (pt.line.intersectsLine(pLo.line))
                                return true;
                        }
                        else
                        {
                            Debug.Print("  skipping endpoint " + pLo.ToString());
                        }
                    }
                }
            }
            return false;
        }
    }
