    class MyClass {
        private ResourceContext m_context;
    
        public MyClass()
        {
            m_context = ResourceContext.GetForCurrentView();
            m_context.QualifierValues.MapChanged += QualifierValues_MapChanged();
        }
        ...
    }
