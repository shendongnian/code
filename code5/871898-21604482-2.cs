    public static class ObjExtesions
    {
        public static void CopyProperties(this IObj source, IObj destination)
        {
            var properties = typeof(IObj).GetProperties();
            var objAProperties = source.GetType().GetProperties();
            var objBProperties = destination.GetType().GetProperties();
            var common = from p in properties
                         from propA in objAProperties
                         from propB in objBProperties
                         where p.Name == propA.Name && p.Name == propB.Name
                         select Tuple.Create(propA, propB);
            foreach(var tuple in common)
            {
                var value = tuple.Item1.GetValue(source);
                tuple.Item2.SetValue(destination, value);
            }
        }
    }
