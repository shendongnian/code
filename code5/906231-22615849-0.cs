    public class TypeLoader<T> : List<T>
    {
        public const BindingFlags ConstructorSearch =
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.CreateInstance |
            BindingFlags.Instance;
        private void Load(params Assembly[] assemblies)
        {
            foreach (
                Type t in
                    assemblies.SelectMany(
                        asm =>
                            asm.GetTypes()
                                .Where(t => t.IsSubclassOf(typeof (T)) || t.GetInterfaces().Any(i => i == typeof (T)))))
            {
                Add((T) Activator.CreateInstance(t, true));
            }
        }
    }
