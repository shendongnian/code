    public class Serializer
    {
        public static string Serialize(Base baseData)
        {
            var baseType = baseData.GetType().BaseType;
            var baseTypeFieldInfo = baseType.GetProperties();
            var newBaseInstance = new Base();
            var newBaseInstanceType = newBaseInstance.GetType();
            //ONLY gets public properties but could be applied to fields
            var newBaseTypeFieldInfo = newBaseInstanceType.GetProperties();
            foreach (var bt in baseTypeFieldInfo)
            {
                foreach (var nbt in newBaseTypeFieldInfo)
                {
                    if (nbt.Name == bt.Name)
                    {
                        nbt.SetValue(newBaseInstance, bt.GetValue(baseData, null), null);
                    }
                }
            }
            var serializer = new XmlSerializer(typeof(Base));
            var sb = new StringBuilder();
            using (var writer = XmlWriter.Create(sb))
            {
                serializer.Serialize(writer, newBaseInstance);
            }
            return sb.ToString();
        }
    }
    public class Base
    {
        public string Name { get; set; }
    }
    public class Derived : Base
    {
        public string AnotherName { get; set; }
        public new string Name
        {
            get { return base.Name; }
            set { base.Name = value; }
        }
    }
