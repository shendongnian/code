                var interfaceType = typeof(A);
                var classes = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(s => s.GetTypes())
                    .Where(interfaceType.IsAssignableFrom).ToList();
                classes.Remove(typeof(A));
