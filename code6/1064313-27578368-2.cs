        public static class NinjectBindingExtensions
        {
            public static void BindExportsInAssembly(this IBindingRoot root, Assembly assembly)
            {
                root.Bind(c => c.From(assembly)
                                  .IncludingNonePublicTypes()
                                  .SelectAllClasses()
                                  .WithAttribute<ExportAttribute>()
                                  .BindWith<ExportAttributeBindingGenerator>());
            }
        }
