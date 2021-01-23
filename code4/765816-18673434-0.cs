    public int Capacity
        {
            get
            {
                return this.UsedCapacity/this.MaxCapacity;
            }
            set
            {
                if(value > MaxCapacity)
                   throw new Exception("Can't set capacity bigger then max capacity");
                // Your code...
            }
        }
