    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class EmailAddress
    {
        public int PersonId { get; set; }
        public Email Email { get; set; }
    }
    public class Email
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
    public static void Main()
    {
        var people = new[]
        {
            new Person() { Id = 1, Name = "John" },
            new Person() { Id = 2, Name = "Paul" },
            new Person() { Id = 3, Name = "George" },
            new Person() { Id = 4, Name = "Ringo" }
        };
        var addresses = new[]
        {
            new EmailAddress() { PersonId = 2, Email = new Email() { Name = "Paul", Address = "Paul@beatles.com" } },
            new EmailAddress() { PersonId = 3, Email = new Email() { Name = "George", Address = "George@beatles.com" } },
            new EmailAddress() { PersonId = 4, Email = new Email() { Name = "Ringo" } }
        };
        Console.WriteLine("\r\nInner Join:\r\n");
        var innerJoin = people.DynamicJoin(addresses, "Id", "PersonId", "outer.Id", "outer.Name", "inner.Email").ToList();
        innerJoin.ForEach(j => Console.WriteLine($"{j.Id}-{j.Name}: {j?.Email?.Address ?? "<null>"}"));
        Console.WriteLine("\r\nOuter Join:\r\n");
        var leftJoin = people.DynamicLeftJoin(addresses, "Id", "PersonId", "outer.Id", "outer.Name", "inner.Email").ToList();
        leftJoin.ForEach(j => Console.WriteLine($"{j.Id}-{j.Name}: {j?.Email?.Address ?? "<null>"}"));
    }
    public static class DynamicJoinExtensions
    {
        private const string OuterPrefix = "outer.";
        private const string InnerPrefix = "inner.";
        private class Processor<TOuter, TInner>
        {
            private readonly Type _typeOuter = typeof(TOuter);
            private readonly Type _typeInner = typeof(TInner);
            private readonly PropertyInfo _keyOuter;
            private readonly PropertyInfo _keyInner;
            private readonly List<string> _outputFields;
            private readonly Dictionary<string, PropertyInfo> _resultProperties;
            public Processor(string outerKey, string innerKey, IEnumerable<string> outputFields)
            {
                _outputFields = outputFields.ToList();
                //  Check for properties with the same name
                string badProps = string.Join(", ", _outputFields.Select(f => new { property = f, name = GetName(f) })
                    .GroupBy(f => f.name, StringComparer.OrdinalIgnoreCase)
                    .Where(g => g.Count() > 1)
                    .SelectMany(g => g.OrderBy(f => f.name, StringComparer.OrdinalIgnoreCase).Select(f => f.property)));
                if (!string.IsNullOrEmpty(badProps))
                    throw new ArgumentException($"One or more {nameof(outputFields)} are duplicated: {badProps}");
                _keyOuter = _typeOuter.GetProperty(outerKey);
                _keyInner = _typeInner.GetProperty(innerKey);
                //  Check for valid keys
                if (_keyOuter == null || _keyInner == null)
                    throw new ArgumentException($"One or both of the specified keys is not a valid property");
                //  Check type compatibility
                if (_keyOuter.PropertyType != _keyInner.PropertyType)
                    throw new ArgumentException($"Keys must be the same type. ({nameof(outerKey)} type: {_keyOuter.PropertyType.Name}, {nameof(innerKey)} type: {_keyInner.PropertyType.Name})");
                Func<string, Type, IEnumerable<KeyValuePair<string, PropertyInfo>>> getResultProperties = (prefix, type) =>
                   _outputFields.Where(f => f.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                       .Select(f => new KeyValuePair<string, PropertyInfo>(f, type.GetProperty(f.Substring(prefix.Length))));
                //  Combine inner/outer outputFields with PropertyInfo into a dictionary
                _resultProperties = getResultProperties(OuterPrefix, _typeOuter).Concat(getResultProperties(InnerPrefix, _typeInner))
                    .ToDictionary(k => k.Key, v => v.Value, StringComparer.OrdinalIgnoreCase);
                //  Check for properties that aren't found
                badProps = string.Join(", ", _resultProperties.Where(kv => kv.Value == null).Select(kv => kv.Key));
                if (!string.IsNullOrEmpty(badProps))
                    throw new ArgumentException($"One or more {nameof(outputFields)} are not valid: {badProps}");
                //  Check for properties that aren't the right format
                badProps = string.Join(", ", _outputFields.Where(f => !_resultProperties.ContainsKey(f)));
                if (!string.IsNullOrEmpty(badProps))
                    throw new ArgumentException($"One or more {nameof(outputFields)} are not valid: {badProps}");
            }
            //  Inner Join
            public IEnumerable<dynamic> Join(IEnumerable<TOuter> outer, IEnumerable<TInner> inner) =>
                outer.Join(inner, o => GetOuterKeyValue(o), i => GetInnerKeyValue(i), (o, i) => CreateItem(o, i));
            //  Left Outer Join
            public IEnumerable<dynamic> LeftJoin(IEnumerable<TOuter> outer, IEnumerable<TInner> inner) =>
                outer.LeftJoin(inner, o => GetOuterKeyValue(o), i => GetInnerKeyValue(i), (o, i) => CreateItem(o, i));
            private static string GetName(string fieldId) => fieldId.Substring(fieldId.IndexOf('.') + 1);
            private object GetOuterKeyValue(TOuter obj) => _keyOuter.GetValue(obj);
            private object GetInnerKeyValue(TInner obj) => _keyInner.GetValue(obj);
            private object GetResultProperyValue(string key, object obj) => _resultProperties[key].GetValue(obj);
            private dynamic CreateItem(TOuter o, TInner i)
            {
                var obj = new ExpandoObject();
                var dict = (IDictionary<string, object>)obj;
                _outputFields.ForEach(f =>
                {
                    var source = f.StartsWith(OuterPrefix, StringComparison.OrdinalIgnoreCase) ? (object)o : i;
                    dict.Add(GetName(f), source == null ? null : GetResultProperyValue(f, source));
                });
                return obj;
            }
        }
        
        public static IEnumerable<dynamic> DynamicJoin<TOuter, TInner>(this IEnumerable<TOuter> outer,
                IEnumerable<TInner> inner, string outerKey, string innerKey,
                params string[] outputFields) =>
            new Processor<TOuter, TInner>(outerKey, innerKey, outputFields).Join(outer, inner);
        public static IEnumerable<dynamic> DynamicLeftJoin<TOuter, TInner>(this IEnumerable<TOuter> outer,
                IEnumerable<TInner> inner, string outerKey, string innerKey,
                params string[] outputFields) =>
            new Processor<TOuter, TInner>(outerKey, innerKey, outputFields).LeftJoin(outer, inner);
    }
