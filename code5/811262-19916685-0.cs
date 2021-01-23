    public partial class NorthwindDataContext
    {
        public override void SubmitChanges(ConflictMode failureMode)
        {
            this.EmptyNullProperties();
            
            base.SubmitChanges(failureMode);
        }
        private void EmptyNullProperties()
        {
            var propertiesToEmpty =
                from entity in this.GetChangeSet().Inserts
                from property in entity.GetType().GetProperties()
                where property.CanRead && property.CanWrite
                where property.PropertyType == typeof(string)
                where property.GetValue(entity) == null
                select new { entity, property };
        
            foreach (var pair in propertiesToEmpty)
            {
                pair.property.SetValue(pair.entity, string.Empty);
            }
        }
    } 
