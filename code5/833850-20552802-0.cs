    public static class Extensions
    {
        public static bool Extension(this object obj, string namearq)
        {
            Boolean sirve; string exte;
    
            exte = Path.GetExtension(namearq);
            return (exte == ".xml");
        }
    }
