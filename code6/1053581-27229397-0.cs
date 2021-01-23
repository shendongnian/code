    public class A
    {
        public string Name { get; set; }
        public string Color1 { get; set; }
        public string Color2 { get; set; }
        public string Length { get; set; }
        public static IEnumerable<A> Intersecting(IEnumerable<A> input, List<string> propertyNames)
        { 
            if(input == null)
                throw new ArgumentNullException("input must not be null ", "input");
            if (!input.Any() || propertyNames.Count <= 1)
                return input;
            var properties = typeof(A).GetProperties();
            var validNames = properties.Select(p => p.Name);
            if (propertyNames.Except(validNames, StringComparer.InvariantCultureIgnoreCase).Any())
                throw new ArgumentException("All properties must must one of these: " + string.Join(",", validNames), "propertyNames");
            
            var props = from prop in properties
                        join name in propertyNames.Intersect(validNames, StringComparer.InvariantCultureIgnoreCase)
                        on prop.Name equals name
                        select prop;
            var allIntersecting = input
                .Select(a => new { 
                    Object = a,
                    FirstVal = props.First().GetValue(a, null),
                    Rest = props.Skip(1).Select(p => p.GetValue(a, null)),
                })
                .Select(x => new { 
                    x.Object, x.FirstVal, x.Rest,
                    UniqueValues = new HashSet<object>{ x.FirstVal }
                })
                .Where(x => x.Rest.All(v => !x.UniqueValues.Add(v)))
                .Select(x => x.Object);
            return allIntersecting;
        }
    }
