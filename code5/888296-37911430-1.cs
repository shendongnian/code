    [NUnitAddin]
    public class ProgressReporterNugetAddin : IAddin
    {
        public bool Install(IExtensionHost host)
        {
            var listeners = host.GetExtensionPoint("EventListeners");
            listeners.Install(new ProgressReporterEventListener());
            return true;
        }
    }
