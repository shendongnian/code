    public class NhInterceptor : EmptyInterceptor
    {
        public override bool OnSave(object entity, object id, object[] state, 
            string[] propertyNames, NHibernate.Type.IType[] types)
        {
            var baseEntity = entity as EntityBase;
            if (baseEntity == null)
                return false;
            var lastModificationPropName = ExpressionUtil
                .GetPropertyName<EntityBase>((e) => e.LastModification);
            for (int i = 0; i < propertyNames.Length; i++)
            {
                if (lastModificationPropName == propertyNames[i])
                {
                    state[i] = DateTime.Now;
                    return true;
                }
            }
            return true;
        }
        public override bool OnFlushDirty(object entity, object id, 
            object[] currentState, object[] previousState, 
            string[] propertyNames, NHibernate.Type.IType[] types)
        {
            var baseEntity = entity as EntityBase;
            if (baseEntity == null)
                return false;
            var lastModificationPropName = ExpressionUtil
                .GetPropertyName<EntityBase>((e) => e.LastModification);
            for (int i = 0; i < propertyNames.Length; i++)
            {
                if (lastModificationPropName == propertyNames[i])
                {
                    currentState[i] = DateTime.Now;
                    return true;
                }
            }
            return true;
        }
    }
