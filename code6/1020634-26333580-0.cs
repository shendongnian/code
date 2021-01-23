    [Serializable]
    [TypeConverter(typeof(CornerRadiiConverter))]
    public struct CornerRadii
    {
        private bool all;
        private int topLeft, topRight, bottomLeft, bottomRight;
        public readonly static CornerRadii Empty;
        [RefreshProperties(RefreshProperties.All)]
        public int All
        {
            get
            {
                if (!this.all)
                    return -1;
                return this.topLeft;
            }
            set
            {
                if (!this.all || this.topLeft != value)
                {
                    this.all = true;
                    this.topLeft = value;
                    this.topRight = value;
                    this.bottomLeft = value;
                    this.bottomRight = value;
                }
            }
        }
        [RefreshProperties(RefreshProperties.All)]
        public int TopLeft
        {
            get
            {
                return this.topLeft;
            }
            set
            {
                if (this.all || this.topLeft != value)
                {
                    this.all = false;
                    this.topLeft = value;
                }
            }
        }
        [RefreshProperties(RefreshProperties.All)]
        public int TopRight
        {
            get
            {
                if (this.all)
                    return this.topLeft;
                return this.topRight;
            }
            set
            {
                if (this.all || this.topRight != value)
                {
                    this.all = false;
                    this.topRight = value;
                }
            }
        }
        [RefreshProperties(RefreshProperties.All)]
        public int BottomLeft
        {
            get
            {
                if (this.all)
                    return this.topLeft;
                return this.bottomLeft;
            }
            set
            {
                if (this.all || this.bottomLeft != value)
                {
                    this.all = false;
                    this.bottomLeft = value;
                }
            }
        }
        [RefreshProperties(RefreshProperties.All)]
        public int BottomRight
        {
            get
            {
                if (this.all)
                    return this.topLeft;
                return this.bottomRight;
            }
            set
            {
                if (this.all || this.bottomRight != value)
                {
                    this.all = false;
                    this.bottomRight = value;
                }
            }
        }
        static CornerRadii()
        {
            CornerRadii.Empty = new CornerRadii(0);
        }
        public CornerRadii(int all)
        {
            this.all = true;
            this.topLeft = all;
            this.topRight = all;
            this.bottomLeft = all;
            this.bottomRight = all;
        }
        public CornerRadii(int topLeft, int topRight, int bottomLeft, int bottomRight)
        {
            this.topLeft = topLeft;
            this.topRight = topRight;
            this.bottomLeft = bottomLeft;
            this.bottomRight = bottomRight;
            this.all = (this.topLeft != this.topRight || this.topLeft != this.bottomRight ? false : this.topLeft == this.bottomRight);
        }
        internal bool ShouldSerializeAll()
        {
            return this.all;
        }
    }
    public class CornerRadiiConverter : TypeConverter
    {
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public CornerRadiiConverter()
        {
        }
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(InstanceDescriptor))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            string str = value as string;
            if (str == null)
                return base.ConvertFrom(context, culture, value);
            str = str.Trim();
            if (str.Length == 0)
                return null;
            if (culture == null)
                culture = CultureInfo.CurrentCulture;
            char delimiter = culture.TextInfo.ListSeparator[0];
            string[] strArray = str.Split(new char[] { delimiter });
            int[] numArray = new int[strArray.Length];
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));
            for (int i = 0; i < numArray.Length; i++)
                numArray[i] = (int)converter.ConvertFromString(context, culture, strArray[i]);
            if (numArray.Length != 4)
            {
                object[] objArray = new object[] { "value", str, "topLeft, topRight, bottomLeft, bottomRight" };
                throw new ArgumentException();
            }
            return new CornerRadii(numArray[0], numArray[1], numArray[2], numArray[3]);
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == null)
                throw new ArgumentNullException("destinationType");
            if (value is CornerRadii)
                if (destinationType == typeof(string))
                {
                    CornerRadii cornerRadii = (CornerRadii)value;
                    if (culture == null)
                        culture = CultureInfo.CurrentCulture;
                    string str = string.Concat(culture.TextInfo.ListSeparator, " ");
                    TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));
                    string[] strArrays = new string[4];
                    strArrays[0] = converter.ConvertToString(context, culture, cornerRadii.TopLeft);
                    strArrays[1] = converter.ConvertToString(context, culture, cornerRadii.TopRight);
                    strArrays[2] = converter.ConvertToString(context, culture, cornerRadii.BottomLeft);
                    strArrays[3] = converter.ConvertToString(context, culture, cornerRadii.BottomRight);
                    return string.Join(str, strArrays);
                }
                if (destinationType == typeof(InstanceDescriptor))
                {
                    CornerRadii cornerRadii1 = (CornerRadii)value;
                    if (cornerRadii1.ShouldSerializeAll())
                    {
                        ConstructorInfo constructor = typeof(CornerRadii).GetConstructor(new Type[] { typeof(int) });
                        object[] all = new object[] { cornerRadii1.All };
                        return new InstanceDescriptor(constructor, all);
                    }
                    Type type = typeof(CornerRadii);
                    Type[] typeArray = new Type[] { typeof(int), typeof(int), typeof(int), typeof(int) };
                    ConstructorInfo constructorInfo = type.GetConstructor(typeArray);
                    object[] left = new object[] { cornerRadii1.TopLeft, cornerRadii1.TopRight, cornerRadii1.BottomLeft, cornerRadii1.BottomRight };
                    return new InstanceDescriptor(constructorInfo, left);
                }
            return base.ConvertTo(context, culture, value, destinationType);
        }
        public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            if (propertyValues == null)
                throw new ArgumentNullException("propertyValues");
            CornerRadii value = (CornerRadii)context.PropertyDescriptor.GetValue(context.Instance);
            int item = (int)propertyValues["All"];
            if (value.All != item)
                return new CornerRadii(item);
            return new CornerRadii((int)propertyValues["TopLeft"], (int)propertyValues["TopRight"], (int)propertyValues["BottomLeft"], (int)propertyValues["BottomRight"]);
        }
        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(CornerRadii), attributes);
            string[] strArrays = new string[] { "All", "TopLeft", "TopRight", "BottomLeft", "BottomRight" };
            return properties.Sort(strArrays);
        }
        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
    }
