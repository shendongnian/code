            /// <summary>
            /// Before compare latitude, than longitude
            /// </summary>
            public int Compare(Point first, Point second)
            {
                var latCompare = Compare(first.Latitude, second.Latitude);
                if (latCompare == 0)
                    return Compare(first.Longitude, second.Longitude);
                return latCompare;
            }
