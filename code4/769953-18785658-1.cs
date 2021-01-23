        /// <summary>
        /// Returns the Id of the entity reference or Guid.Empty if it is null"
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static Guid GetIdOrDefault(this EntityReference entity)
        {
            if (entity == null)
            {
                return Guid.Empty;
            }
            else
            {
                return entity.Id;
            }
        }
