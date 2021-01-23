    if (CurrentContainer.IsNull()) {
                lock (m_lockObject) {
                    if (CurrentContainer.IsNull()) {
                        var container = CreateContainer();
                        CurrentContainer.SetCurrentContainer(container);
                        ControllerBuilder.Current.SetControllerFactory(new MefControllerFactory(container));
                        System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver =
                            new MefDependencyResolver(container);
                    }
                }
            }
