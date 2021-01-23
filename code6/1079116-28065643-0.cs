    private string FindObject(Stack<object> self, Type typeToFind, string path)
    {
        var _self = self.Peek();
        if (self.Where(x => x.Equals(_self)).Count() > 1) return null;
        foreach (var prop in _self.GetType().GetProperties().Where(x => !x.GetIndexParameters().Any() && !x.GetCustomAttributes(true).Any(y => y is XmlIgnoreAttribute)))
        {
            var line = string.Format("{0}::{1}", path, prop.Name);
            if (typeToFind.IsAssignableFrom(prop.PropertyType))
                return line;
            if (prop.PropertyType.IsPrimitive || prop.PropertyType == typeof(DateTime) || prop.PropertyType == typeof(string))
                continue;
            var subInst = prop.GetValue(_self, new object[0]);
            if (subInst == null)
                continue;
            self.Push(subInst);
            var result = FindObject(self, typeToFind, line);
            self.Pop();
            if (result != null)
                return result;
        }
        if (_self is IEnumerable)
        {
            var list = (_self as IEnumerable).Cast<object>(); 
            var index = 0;
            foreach(var item in list)
            {               
                self.Push(item);
                var result = FindObject(self, typeToFind, string.Format("{0}[{1}]", path, index));
                self.Pop();
                index++;
                if (result != null)
                    return result;
            }
        }
        return null;
    }
