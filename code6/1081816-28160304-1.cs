        public static int CompareById(Widget_C x, Widget_C y)
        {
            if (x == null || y == null) // null check up front
            {
                // minor performance hit in doing null checks multiple times, but code is much more 
                // readable and null values should be a rare outside case.
                if (x == null && y == null) { return 0; } // both null
                else if (x == null) { return -1; } // only x is null
                else { return 1; } // only y is null
            }
            else { return x.Id.CompareTo(y.Id); }
        }
