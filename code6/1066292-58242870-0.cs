csharp
internal partial class Language : IDictionary<string, object>
{
    [YamlMember(Alias = "namespace")]
    public string Namespace { get; set; }
    [YamlMember(Alias = "discriminatorValue")]
    public string DiscriminatorValue { get; set; }
    [YamlMember(Alias = "uid")]
    public string Uid { get; set; }
    [YamlMember(Alias = "internal")]
    public bool Internal { get; set; }
    [YamlIgnore]
    public IDictionary<string, object> AdditionalProperties = new Dictionary<string, object>();
    private readonly Dictionary<string, object> _dictionary = new Dictionary<string, object>();
    private static readonly Dictionary<string, PropertyInfo> DeserializableProperties = typeof(Language).GetDeserializableProperties();
    // Workaround for mapping properties from the dictionary entries
    private void AddAndMap(string key, object value)
    {
        _dictionary.Add(key, value);
        if (DeserializableProperties.ContainsKey(key))
        {
            var propInfo = DeserializableProperties[key];
            propInfo.SetValue(this, propInfo.DeserializeDictionary(value));
            return;
        }
        AdditionalProperties.Add(key, value);
    }
    public IEnumerator<KeyValuePair<string, object>> GetEnumerator() => _dictionary.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    public void Add(KeyValuePair<string, object> item) => AddAndMap(item.Key, item.Value);
    public void Clear() => _dictionary.Clear();
    public bool Contains(KeyValuePair<string, object> item) => _dictionary.ContainsKey(item.Key);
    public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
    {
        foreach (var item in _dictionary)
        {
            array[arrayIndex++] = item;
        }
    }
    public bool Remove(KeyValuePair<string, object> item) => _dictionary.Remove(item.Key);
    public int Count => _dictionary.Count;
    public bool IsReadOnly => false;
    public void Add(string key, object value) => AddAndMap(key, value);
    public bool ContainsKey(string key) => _dictionary.ContainsKey(key);
    public bool Remove(string key) => _dictionary.Remove(key);
    public bool TryGetValue(string key, out object value) => _dictionary.TryGetValue(key, out value);
    public object this[string key]
    {
        get => _dictionary[key];
        set => AddAndMap(key, value);
    }
    public ICollection<string> Keys => _dictionary.Keys;
    public ICollection<object> Values => _dictionary.Values;
}
In this example, `Language` is the class I'm trying to deserialize. I have other properties on this class as part of my generated classes (via the JSON schema generator). Since they are partial, I can implement this workaround.
Basically, I created `AddAndMap` and applied it to anywhere in the interface that adds dictionary entries. I also created the `AdditionalProperties` dictionary to hold our values. Keep in mind that we need all the values in the `IDictionary` for serializing this class properly.
Next, I always add the entry to the backing `_dictionary` and then determine if I have a property to provide the value to. If I don't have a property that this value should map to, I put the value into the `AdditionalProperties` dictionary instead.
To determine if I have an available property for deserization, I had to write a few extension methods.
csharp
public static Dictionary<string, PropertyInfo> GetDeserializableProperties(this Type type) => type.GetProperties()
    .Select(p => new KeyValuePair<string, PropertyInfo>(p.GetCustomAttributes<YamlMemberAttribute>(true).Select(yma => yma.Alias).FirstOrDefault(), p))
    .Where(pa => !pa.Key.IsNullOrEmpty()).ToDictionary(pa => pa.Key, pa => pa.Value);
// Only allows deserialization of properties that are primitives or type Dictionary<object, object>. Does not support properties that are custom classes.
public static object DeserializeDictionary(this PropertyInfo info, object value)
{
    if (!(value is Dictionary<object, object>)) return TypeConverter.ChangeType(value, info.PropertyType);
    var type = info.PropertyType;
    var properties = type.GetDeserializableProperties();
    var property = Activator.CreateInstance(type);
    var matchedProperties = ((Dictionary<object, object>)value).Where(e => properties.ContainsKey(e.Key.ToString()));
    foreach (var (propKey, propValue) in matchedProperties)
    {
        var innerInfo = properties[propKey.ToString()];
        innerInfo.SetValue(property, innerInfo.DeserializeDictionary(propValue));
    }
    return property;
}
Main thing to note is that this only works on properties of the class that are primitives or `Dictionary<object, object>`. The reason is because it uses `TypeConverter.ChangeType` to return the appropriate object when setting the property. If you made a way to interpret how custom classes would be created, you would just replace the `TypeConverter.ChangeType` call with that solution.
To get the deserializable properties of a class, I use reflection to get the `YamlMemberAttribute` of the properties on that class. Then, I put the `PropertyInfo` of that property into a dictionary where the key is the value of `Alias` from the `YamlMemberAttribute`. In my solution here, **all properties require an alias to be defined for the property**.
Then, I find the property with an alias that matches the key that I got from the `AddAndMap` call. This recursively happens so that (in the future) it would be possible to have this work with custom class properties. It checks for `Dictionary<object, object>` as the value type because `YamlDotNet`, when deserializing something into a dictionary, will always deserialize sub-classes into `Dictionary<object, object>`.
## Overall
This solution works and could be simplified if you only have flat (no custom class properties) of the class you are trying to deserialize. Or, it could be extended to support custom class properties. The solution could also be made into a base type that your other classes derive from, and you'd do `GetType()` in `DeserializableProperties` instead of `typeof(Language)`. It is an overly verbose solution, but until `YamlDotNet` has a cleaner/simpler/proper solution, this was the best I could come up with after exploring their source code.
Lastly, keep in mind that because your class derives of `IDictionary`, `YamlDotNet` **will not serialize any properties from your class**, even if they have the `YamlMember` attributes on them. If `YamlDotNet` would provide that functionality, I had a cleaner solution in mind originally. Alas, that is not the case.
