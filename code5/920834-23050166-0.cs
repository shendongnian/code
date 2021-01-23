    //Custom attribute class
    sealed class RedirectedPropertyAttribute : Attribute
    {
        readonly string targetProperty;
        public RedirectedPropertyAttribute(string TargetProperty)
        {
            this.targetProperty = TargetProperty;
        }
        public string TargetProperty
        {
            get { return targetProperty; }
        }
    }
    //Type converter
    public class TypeConverter
    {
        public static T Convert<T, S>(S Source) where T : class, new() where S : class, new()
        {
            //If no instance is passed just return null
            if (Source == null)
                return null;
            //Get types of items
            Type typeOfTarget = typeof(T);
            Type typeOfSource = typeof(S);
            //Get properties of items
            var sourceProperties = typeOfSource.GetProperties();
            var targetProperties = typeOfTarget.GetProperties();
            //Create a new instance of T
            var instance = Activator.CreateInstance<T>();
            foreach (var prop in sourceProperties)
            {
                //Get or attributes
                var attribs = prop.GetCustomAttributes(typeof(RedirectedPropertyAttribute), false); //If you want to inherit the attributes change to yes
                //If it's not marked or marked more than once, continue (really a bad error ;))
                if (attribs == null || attribs.Length != 1)
                    continue;
                //Cast the attribute
                RedirectedPropertyAttribute attrib = attribs[0] as RedirectedPropertyAttribute;
                //No property set? ignore this property
                if (string.IsNullOrWhiteSpace(attrib.TargetProperty))
                    continue;
                //Find the target property in target type
                var tProp = targetProperties.Where(t => t.Name == attrib.TargetProperty).FirstOrDefault();
                //Not found? ignore this property
                if (tProp == null)
                    continue;
                try
                {
                    //Why this try-catch?
                    //Because if types don't match an exception can be thrown
                    //but it's easier than comparing types (because if an int is mapped to a long we want it to be set)
                    //WARNING!!, assuming non-indexed properties!
                    tProp.SetValue(instance, prop.GetValue(Source, null), null);
                }
                catch { }
            }
            //Return new class
            return instance;
        
        }
    
    }
    //Class from source A
    public class A
    {
        [RedirectedProperty("Id")]
        public int IdOfA { get; set; }
        [RedirectedProperty("Name")]
        public string StringOfA { get; set; }
    
    }
    //Class from source B
    public class B
    {
        [RedirectedProperty("Id")]
        public int IdOfB { get; set; }
        [RedirectedProperty("Name")]
        public string StringOfB { get; set; }
    
    }
    //Hub class for A or B
    public class ABHub
    {
        public int Id { get; set; }
        public string Name { get; set; }
 
    }
    //And to use:
    ABHub ACasted = TypeConverter.Convert<ABHub, A>(new A{ IdOfA = 33, StringOfA = "MyNameIsA" });
    ABHub BCasted = TypeConverter.Convert<ABHub, B>(new B{ IdOfB = 33, StringOfB = "MyNameIsB" });
