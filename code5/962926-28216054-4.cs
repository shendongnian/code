        /// <summary>
        /// Registers a callback that will be invoked to create an instance of type T that will be stored in the OwinContext which can fetched via context.Get
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="app"></param>
        /// <param name="createCallback"></param>
        /// <returns></returns>
        public static IAppBuilder CreatePerOwinContext<T>(this IAppBuilder app, Func<IdentityFactoryOptions<T>, IOwinContext, T> createCallback) where T : class,IDisposable {
            if (app == null) {
                throw new ArgumentNullException("app");
            }
            if (createCallback == null) {
                throw new ArgumentNullException("createCallback");
            }
 
            app.Use(typeof(IdentityFactoryMiddleware<T, IdentityFactoryOptions<T>>),
                new IdentityFactoryOptions<T>() {
                    DataProtectionProvider = app.GetDataProtectionProvider(),
                    Provider = new IdentityFactoryProvider<T>() {
                        OnCreate = createCallback
                    }
                });
            return app;
        }
