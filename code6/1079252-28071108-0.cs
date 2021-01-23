            string Items = "";
            IEnumerable<Assembly> Assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>();
            foreach (Assembly FoundAssembly in Assemblies)
            {
                string AssemblyName = FoundAssembly.FullName;
                IEnumerable<TypeInfo> Types = FoundAssembly.DefinedTypes.Where(type => type != null && type.IsPublic && type.IsClass && !type.IsAbstract && typeof(ApiController).IsAssignableFrom(type));
                foreach (TypeInfo ControllerType in Types)
                {
                    System.Web.Http.Controllers.ApiControllerActionSelector ApiControllerSelection = new System.Web.Http.Controllers.ApiControllerActionSelector();
                    System.Web.Http.Controllers.HttpControllerDescriptor ApiDescriptor = new System.Web.Http.Controllers.HttpControllerDescriptor(new System.Web.Http.HttpConfiguration(), ControllerType.Name, ControllerType);
                    ILookup<string, System.Web.Http.Controllers.HttpActionDescriptor> ApiMappings = ApiControllerSelection.GetActionMapping(ApiDescriptor);
                    foreach (var Maps in ApiMappings)
                    {
                        foreach (System.Web.Http.Controllers.HttpActionDescriptor Actions in Maps)
                        {
                            Items += "[ controller=" + ControllerType.Name + " action=" + ((System.Web.Http.Controllers.ReflectedHttpActionDescriptor)(Actions)).MethodInfo + "]";
                        }
                    }
                }
            }
