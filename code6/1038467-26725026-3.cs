    public class XmlSerializerConfigurator<T>
    {
        private readonly XmlAttributeOverrides _xmlAttributeOverrides;
        public XmlSerializerConfigurator(XmlAttributeOverrides xmlAttributeOverrides)
        {
            _xmlAttributeOverrides = xmlAttributeOverrides;
        }
        public XmlSerializerConfigurator() : this(new XmlAttributeOverrides())
        {
        }
        /// <summary>
        /// Adds attributes to properties or fields and strongly typed
        /// </summary>
        /// <typeparam name="TData"></typeparam>
        /// <param name="property"></param>
        /// <param name="xmlAttributes"></param>
        /// <returns></returns>
        public XmlSerializerConfigurator<T> AddPropertyOrFieldAttributes<TData>(Expression<Func<T, TData>> property,
                                                        params Attribute[] xmlAttributes)
        {
            var memberName = property.GetName();
            _xmlAttributeOverrides.Add(typeof (T), memberName,
                                       new XmlAttributes(new CustomAttributeProvider(xmlAttributes)));
            return this;
        }
        /// <summary>
        /// Adds class level attributes
        /// </summary>
        /// <param name="xmlAttributes"></param>
        /// <returns></returns>
        public XmlSerializerConfigurator<T> AddClassLevelAttributes(params Attribute[] xmlAttributes)
        {
            _xmlAttributeOverrides.Add(typeof(T), new XmlAttributes(new CustomAttributeProvider(xmlAttributes)));
            return this;
        }
        /// <summary>
        /// Creates an XmlSerializerConfigurator that is tied to the main one
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <returns></returns>
        public XmlSerializerConfigurator<K> ChildClassConfigurator<K>()
        {
            // passes in own XmlAttributeOverrides and since object reference it will fill the same object 
            return new XmlSerializerConfigurator<K>(_xmlAttributeOverrides);
        }
        /// <summary>
        /// Returns back an XmlSerializer with this configuration
        /// </summary>
        /// <returns></returns>
        public XmlSerializer GetSerializer()
        {
            return new XmlSerializer(typeof(T), _xmlAttributeOverrides);
        }
    }
