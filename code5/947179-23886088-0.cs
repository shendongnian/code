    class W
    {
        public bool Update(IId id)
        {
            dynamic d_id = id;
            return Update(d_id);
        }
        
        // ...
    }
