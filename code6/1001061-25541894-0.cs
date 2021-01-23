    foreach(var item in section.DatabaseSettings.Select(p=>p.id))
    {
    DBID.Items.Add(item);
    }
    [ConfigurationCollection( typeof (DatabaseElement))]
        public class DatabaseCollection : ConfigurationElementCollection, IEnumerable<DatabaseElement>
        {
            protected override ConfigurationElement CreateNewElement()
            {
                return new DatabaseElement();
            }
    
            protected override object GetElementKey(ConfigurationElement element)
            {
                return ((DatabaseElement)(element)).id;
            }
    
            public DatabaseElement this [string idx]
            {
                get
                {
                    return (DatabaseElement)BaseGet(idx);
                }
            }
    
        #region IEnumerable<DatabaseElement> Members
    
     
            public new IEnumerator<DatabaseElement> GetEnumerator()
            {
                int count = base.Count;
                for (int i = 0; i < count; i++)
                {
                    yield return base.BaseGet(i) as DatabaseElement;
                }
            }
     
            #endregion
        }
