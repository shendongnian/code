        private class CompositionHost: IPartImportsSatisfiedNotification
        {
            [Import(typeof (IPlugin))] private IPlugin _plugin;
            public IAsyncPlugin Plugin { get; private set; }
            public void OnImportsSatisfied()
            {
                Plugin = new AsyncPlugin(_plugin);
            }
            private sealed class AsyncPlugin : IAsyncPlugin
            {
                private readonly IPlugin _plugin;
                public AsyncPlugin(IPlugin plugin)
                {
                    _plugin = plugin;
                }
                public Task Method()
                {
                    return Task.Factory.StartNew(() => _plugin.Method());
                }
            }
        }
    }
	
