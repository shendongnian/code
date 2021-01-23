        public static DbSet GetAbandonCodes(Type t)
        {
            DbSet ab;
            using (DataWarehouseEntities context = new DataWarehouseEntities ())
            {
                ab = context.Set(t);
            }
            return ab;
        }
