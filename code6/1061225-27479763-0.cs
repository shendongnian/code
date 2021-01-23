    public class AConstructorSelector : IConstructorSelector
    {
        public ConstructorParameterBinding SelectConstructorBinding(ConstructorParameterBinding[] constructorBindings)
        {
            if (constructorBindings == null) throw new ArgumentNullException("constructorBindings");
            if (constructorBindings.Length == 0) throw new ArgumentOutOfRangeException("constructorBindings");
            if (constructorBindings.Length == 1)
                return constructorBindings[0];
            var withLength = constructorBindings
                .Where(b => !b.TargetConstructor.GetParameters().Select(p => p.ParameterType).Contains(typeof(A)))
                .Select(binding => new { Binding = binding, ConstructorParameterLength = binding.TargetConstructor.GetParameters().Length })
                .ToArray();
            var maxLength = withLength.Max(binding => binding.ConstructorParameterLength);
            var maximal = withLength
                .Where(binding => binding.ConstructorParameterLength == maxLength)
                .Select(ctor => ctor.Binding)
                .ToArray();
            if (maximal.Length == 1)
                return maximal[0];
            throw new DependencyResolutionException("Unable to find constructor");
        }
    }
