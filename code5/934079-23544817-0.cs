        public string GetRootDir()
        {
            Type type = isoStore.GetType();
            FieldInfo field = type.GetField("m_RootDir", System.Reflection.BindingFlags.NonPublic | BindingFlags.Instance);
            string rootDir = field.GetValue(isoStore).ToString();
            return rootDir;
        }
