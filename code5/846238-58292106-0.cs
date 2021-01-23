            public static string GetDataMemberName(this MyClass theClass, string thePropertyName)
        {
            var pi = typeof(MyClass).GetProperty(thePropertyName);
            if (pi == null) throw new ApplicationException($"{nameof(MyClass)}.{thePropertyName} does not exist");
            var ca = pi.GetCustomAttribute(typeof(DataMemberAttribute), true) as DataMemberAttribute;
            if (ca == null) throw new ApplicationException($"{nameof(MyClass)}.{thePropertyName} does not have DataMember Attribute"); // or return thePropertyName?
            return ca.Name;
        }
