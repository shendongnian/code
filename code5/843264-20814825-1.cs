    bananas.Sort(
        delegate(Banana b1, Banana b2)
        {          
            int res = b1.Color.CompareTo(b2.Color);
            return res != 0 ? res : b1.Position.CompareTo(b2.Position);
        });
