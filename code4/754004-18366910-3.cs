    public GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : EntityBaseClass{
        //REMOVED IRRELEVANT CODE
        private MyContextType _context;
        public virtual void AddBulk<IEnumerable<TEntity> toAdd, string connectionString, int batchSize)
        {
            using (SqlBulkCopy sbc = new SqlBulkCopy(connectionString, SqlBulkCopyOptions.TableLock | SqlBulkCopyOptions.CheckContstraints | SqlBulkCopyOptions.KeepIdentity))
            {
                sbc.DestinationTableName = _context.GetTableAndSchema<TEntity>();
                //DO THE REST OF SQL BULK COPY
            }
        }
    }
