public class CustomConstructorResolver : DefaultContractResolver
{
    public string ConstructorAttributeName { get; set; } = "JsonConstructorAttribute";
    public bool IgnoreAttributeConstructor { get; set; } = false;
    public bool IgnoreSinglePrivateConstructor { get; set; } = false;
    public bool IgnoreMostSpecificConstructor { get; set; } = false;
    protected override JsonObjectContract CreateObjectContract(Type objectType)
    {
        var contract = base.CreateObjectContract(objectType);
        // Use default contract for non-object types.
        if (objectType.IsPrimitive || objectType.IsEnum) return contract;
        // Look for constructor with attribute first, then single private, then most specific.
        var overrideConstructor = 
               (this.IgnoreAttributeConstructor ? null : GetAttributeConstructor(objectType)) 
            ?? (this.IgnoreSinglePrivateConstructor ? null : GetSinglePrivateConstructor(objectType)) 
            ?? (this.IgnoreMostSpecificConstructor ? null : GetMostSpecificConstructor(objectType));
        // Set override constructor if found, otherwise use default contract.
        if (overrideConstructor != null)
        {
            SetOverrideCreator(contract, overrideConstructor);
        }
        return contract;
    }
    private void SetOverrideCreator(JsonObjectContract contract, ConstructorInfo attributeConstructor)
    {
        contract.OverrideCreator = CreateParameterizedConstructor(attributeConstructor);
        contract.CreatorParameters.Clear();
        foreach (var constructorParameter in base.CreateConstructorParameters(attributeConstructor, contract.Properties))
        {
            contract.CreatorParameters.Add(constructorParameter);
        }
    }
    private ObjectConstructor<object> CreateParameterizedConstructor(MethodBase method)
    {
        var c = method as ConstructorInfo;
        if (c != null)
            return a => c.Invoke(a);
        return a => method.Invoke(null, a);
    }
    protected virtual ConstructorInfo GetAttributeConstructor(Type objectType)
    {
        var constructors = objectType
            .GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .Where(c => c.GetCustomAttributes().Any(a => a.GetType().Name == this.ConstructorAttributeName)).ToList();
        if (constructors.Count == 1) return constructors[0];
        if (constructors.Count > 1)
            throw new JsonException($"Multiple constructors with a {this.ConstructorAttributeName}.");
        return null;
    }
    protected virtual ConstructorInfo GetSinglePrivateConstructor(Type objectType)
    {
        var constructors = objectType
            .GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
        return constructors.Length == 1 ? constructors[0] : null;
    }
    protected virtual ConstructorInfo GetMostSpecificConstructor(Type objectType)
    {
        var constructors = objectType
            .GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .OrderBy(e => e.GetParameters().Length);
        var mostSpecific = constructors.LastOrDefault();
        return mostSpecific;
    }
}
Here is the complete version with XML documentation as a gist: https://gist.github.com/maverickelementalch/80f77f4b6bdce3b434b0f7a1d06baa95
Feedback appreciated.
