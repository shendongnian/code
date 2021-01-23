        internal Int64 InternalTicks {
            get {
                return (Int64)(dateData & TicksMask);
            }
        }
