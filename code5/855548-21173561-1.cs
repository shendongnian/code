       public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.EnableSystemDiagnosticsTracing();
            ContainerBuilder builder = new ContainerBuilder();
            //string WebApisPath = ConfigurationManager.AppSettings["AutoFac_WebApiControllerAssembliesPath"];
            string titleLoanAsm = ConfigurationManager.AppSettings["WebApi_TitleLoanAssembly"];
            //Assembly asm = Assembly.LoadFile(AssemblyDirectory.Replace("\\bin", "") + WebApisPath + titleLoanAsm);
            Assembly asm = Assembly.LoadFile(AssemblyDirectory + "\\" + titleLoanAsm);
            List<Type> exportedTypes = new List<Type>(asm.GetExportedTypes());
            Type controller = exportedTypes.FirstOrDefault(t => !t.IsAbstract && typeof(ApiController).IsAssignableFrom(t));
            if (controller == null)
                throw new ObjectNotFoundException(string.Format("Contoller not found in assembly {0}.", asm.FullName));
            
            Type repoClass = exportedTypes.FirstOrDefault(x => x.IsClass && x.Name.Contains("LGF"));
            if (repoClass == null)
                throw new ObjectNotFoundException(string.Format("No repositories found for controller"));
            Type repoInterface = repoClass.GetInterfaces().FirstOrDefault(x => x.IsInterface && x.Name.Contains("LGF"));
            if (repoInterface == null)
                throw new ObjectNotFoundException(string.Format("Interface not found for class {0}. Ensure class has and interface implemented with a name that contains LGF", repoClass.Name));
            RuntimeContainerBuilder.Evaluate(builder, controller, repoInterface, repoClass, asm);
            IContainer container = builder.Build();
            AutofacWebApiDependencyResolver resolver = new AutofacWebApiDependencyResolver(container);
            config.DependencyResolver = resolver;
        }
