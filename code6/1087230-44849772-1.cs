            var engine = new PrecompiledMvcEngine(typeof(RazorGeneratorMvcStart).Assembly)
            {
                UsePhysicalViewsIfNewer = HttpContext.Current.Request.IsLocal,
                PreemptPhysicalFiles = false
            };
            ViewEngines.Engines.Add(engine);
