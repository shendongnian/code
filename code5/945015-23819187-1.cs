        public ObjectQuery<T> CreateNavigationSourceQuery<T>(object entity, string navigationProperty)
        {
            var ose = this.ObjectContext.ObjectStateManager.GetObjectStateEntry(entity);
            var rm = this.ObjectContext.ObjectStateManager.GetRelationshipManager(entity);
            var entityType = (EntityType)ose.EntitySet.ElementType;
            var navigation = entityType.NavigationProperties[navigationProperty];
            var relatedEnd = rm.GetRelatedEnd(navigation.RelationshipType.FullName, navigation.ToEndMember.Name);
            return ((dynamic)relatedEnd).CreateSourceQuery();
        }
