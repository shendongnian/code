    public static class ABExt
    {
        public static ITellMyNameInterface AsITellMyNameInterface(this A self)
        {
            return new AAdapter(self);
        }
        public static ITellMyNameInterface AsITellMyNameInterface(this B self)
        {
            return new BAdapter(self);
        }
    }
