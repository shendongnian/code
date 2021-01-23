		public static class EntityHelper
		{
			public static TEntity WithId<TEntity>(this TEntity entity, int id)
				where TEntity : Entity
			{
				SetId(entity, id);
				return entity;
			}
			private static void SetId<TEntity>(TEntity entity, int id)
				where TEntity : Entity
			{
				var idProperty = GetField(entity.GetType(), "id", BindingFlags.NonPublic | BindingFlags.Instance);
				/* ... */	
				idProperty.SetValue(entity, id);
			}
			public static FieldInfo GetField(Type type, string fieldName, BindingFlags bindibgAttr)
			{
				return type != null
					? (type.GetField(fieldName, bindibgAttr) ?? GetField(type.BaseType, fieldName, bindibgAttr))
					: null;
			}
		}
