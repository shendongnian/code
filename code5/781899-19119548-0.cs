            private const string keyName = "Id";
        public static async Task<IEnumerable<TChild>> GetChildrenAsync<TParent, TChild>(this TParent parent)
            where TParent : Entity
            where TChild : Entity, new()
        {
            var parentType = typeof (TParent);
            var parentName = parentType.GetTypeInfo().Name;
            var parentKeyValue = (int)parentType.GetRuntimeProperty(keyName).GetValue(parent);
            var foreignKeyName = String.Format("{0}{1}", parentName, keyName);
            var childProperty = typeof(TChild).GetRuntimeProperty(foreignKeyName);
            var connection = DbConnection.Current;
            var query = connection.Table<TChild>().Where(c => (int)childProperty.GetValue(c) == parentKeyValue);
            return await query.ToListAsync();
        }
