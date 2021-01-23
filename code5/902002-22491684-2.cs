    public class OperationsFactory
    {
        private GeneralSettingsManager m_generalSettings;
        private Dictionary<OperationType, OperationCreatorBase> m_creators;
        public OperationsFactory(
                GeneralSettingsManager generalSettings,
                IEnumerable<OperationCreatorBase> creators)
        {
            m_generalSettings = generalSettings;
            foreach (var creator in creators)
            {
                m_creators.Add(creator.CreatorOperationType, creator);
            }
        }
        ...
    }
