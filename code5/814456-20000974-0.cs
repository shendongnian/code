    public class TargetManager
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        [ImportMany(typeof(Pruef.Net.Contracts.ITarget))]
        private IEnumerable<Lazy<Pruef.Net.Contracts.ITarget>> _targets;
        public IEnumerable<Pruef.Net.Contracts.ITarget> AvailableTargets
        {
            get;
            private set;
        }
        /// <summary>
        /// Load all known target definitions
        /// </summary>
        public void Init()
        {
            try
            {
                var catalog = new AggregateCatalog();
                var container = new CompositionContainer(catalog);
                var batch = new CompositionBatch();
                batch.AddPart(this);
                catalog.Catalogs.Add(new AssemblyCatalog(typeof(Pruef.Net.TgtManager.TargetManager).Assembly));
                container.Compose(batch);
                List<ITarget> result = new List<ITarget>();
                foreach (Lazy<ITarget> t in _targets)
                {
                    try
                    {
                        result.Add(t.Value);
                    }
                    catch (Exception x)
                    {
                        // could not load plugin
                        // log error and continue
                        log.Error(x);
                    }
                }
                result = result.OrderBy(t => t.DisplayName).ToList();
                AvailableTargets = result;
            }
            catch (Exception x)
            {
                log.Error(x);
            }
        }
    }
}
