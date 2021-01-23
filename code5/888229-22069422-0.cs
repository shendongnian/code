        static object ConvertList<T>(List<string> stringList)
        {
            return stringList.Select(a => (T)Enum.Parse(typeof(T), a)).ToList();
        }
        static object ConvertList(List<string> stringList, Type enumType)
        {
            var method = new Func<List<string>, object>(ConvertList<object>).Method.GetGenericMethodDefinition();
            return method.MakeGenericMethod(enumType).Invoke(null, new object[] { stringList });
        }
