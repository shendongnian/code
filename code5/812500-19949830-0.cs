    public class CompareHelper
            {
        
                Hashtable reccorido = new Hashtable();
                List<IExcludeProperties> excludeProperties = new List<IExcludeProperties>();
                private readonly List<string> genericListPropertiesNames = new List<string>() { "Count", "Capacity", "Item" };
                public CompareHelper():this(new List<IExcludeProperties>())
                {
        
                }
        
                public CompareHelper(List<IExcludeProperties> excludeProperties)
                {
                    this.excludeProperties = excludeProperties;
                }
        
                public bool AreEquals<T1, T2>(T1 value1, T2 value2)
                {
                    try
                    {
                        reccorido = new Hashtable();
                        return Compare(value1, value2);
                    }
                    catch (NotEqualsException ex)
                    {
                        PropertyFail = ex.Where();
                        return false;
                    }
                }
        
                public string PropertyFail
                {
                    get;
                    private set;
                }
        
                private bool Compare<T1, T2>(T1 value1, T2 value2)
                {
                    if (value1 == null && value2 == null)
                    {
                        return true;
                    }
                    if ((value1 == null) || (value2 == null))
                    {
                        throw new NotEqualsException(value1, value2);
                        //return false;
                    }
        
                    string key = GetKey<T1, T2>(value1, value2);
        
                    if (reccorido.Contains(key))
                    {
                        return true;
                    }
        
                    reccorido.Add(key, true);
                    Type tipo1 = GetType(value1.GetType());
                    Type tipo2 = GetType(value2.GetType());
        
        
                    if (tipo1 != tipo2)
                    {
                        throw new NotEqualsException(value1, value2);
                        //  return false;
                    }
        
        
                    if (IsBasicCompare(tipo1))
                    {
                        return CompareBasic(ConvertTo(value1, tipo1), ConvertTo(value2, tipo1));
        
                    }
                    dynamic v1 = ConvertTo(value1, tipo1);
                    dynamic v2 = ConvertTo(value2, tipo1);
                    if (!CompareFields(v1, v2))
                    {
        
                        throw new NotEqualsException(value1, value2);
                        //return false;
                    }
        
        
                    return CompareProperties(v1, v2);
                }
        
                private string GetKey<T1, T2>(T1 value1, T2 value2)
                {
        
                    int hascodeA = value1.GetHashCode();
                    int hascodeB = value2.GetHashCode();
                    if (hascodeA > hascodeB)
                        return string.Format("{0}{1}", hascodeA, hascodeB);
        
                    return string.Format("{0}{1}", hascodeB, hascodeA);
                }
        
                private dynamic ConvertTo(object value1, Type t)
                {
                    if (value1 == null)
                        return null;
                    return Convert.ChangeType(value1, GetType(t));
                }
        
                private bool CompareProperties<T>(T value1, T value2)
                {
        
        
                    if (IsGenericList(typeof(T)))
                    {
                        return ComparareGenericList(value1, value2);
        
                    }
                    List<PropertyInfo> properties = GetPropertiesToCheck<T>();
                    foreach (var p in properties)
                    {
        
        
                        try
                        {
                            var valueA = p.GetValue(value1, null);
                            var valueB = p.GetValue(value2, null);
        
                            if (!(valueA == null && valueB == null))
                            {
                                if (valueA == null || valueB == null)
                                {
                                    throw new NotEqualsException(value1, value2);
                                    // return false;
                                }
        
                                if (IsBasicCompare(p.PropertyType))
                                {
                                    valueA = ConvertTo(p.GetValue(value1, null), p.PropertyType);
                                    valueB = ConvertTo(p.GetValue(value2, null), p.PropertyType);
        
        
                                    if (!CompareBasic(valueA, valueB))
                                    {
                                        throw new NotEqualsException(value1, value2);
        
                                        // return false;
                                    }
        
                                }
                                else if (IsEnumerable(p.PropertyType))
                                {
        
                                    if (!CompareAsInumerable(valueA, valueB))
                                    {
                                        throw new NotEqualsException(value1, value2);
                                        //   return false;
                                    }
                                }
                                else if (p.PropertyType.IsClass)
                                {
                                    if (!Compare(ConvertTo(p.GetValue(value1, null), p.PropertyType), ConvertTo(p.GetValue(value2, null), p.PropertyType)))
                                    {
                                        throw new NotEqualsException(value1, value2);
                                    }
                                }
                                else
                                    throw new Exception(string.Format("Tipo no especificado {0}", p.PropertyType));
                            }
        
                        }
                        
                        catch (NotEqualsException ex)
                        {
                            ex.AddParent(p.Name);
                            throw;
                        }
        
                    }
                    return true;
        
        
                }
        
                private  List<PropertyInfo> GetPropertiesToCheck<T>()
                {
        
                    List<PropertyInfo> properties = new List<PropertyInfo>();
              
                    Type typeToCheck= typeof(T);
                    IExcludeProperties exclude=excludeProperties.FirstOrDefault(excl=>excl.ExcludeType().IsAssignableFrom(typeToCheck));
                    if(exclude!=null)
                        return typeToCheck.GetProperties().Where(p => p.CanRead && (!exclude.GetPropertiesNames().Any(n=>n==p.Name))).ToList();
                    
                   // 
                    return typeToCheck.GetProperties().Where(p => p.CanRead).ToList();
        
                   
                }
        
                private bool ComparareGenericList<T>(T value1, T value2)
                {
        
                    List<PropertyInfo> properties = typeof(T).GetProperties().Where(p => p.CanRead && p.Name != "Capacity").ToList(); //la capacidad no la compruebo!!
        
        
                    PropertyInfo count = typeof(T).GetProperty("Count");
        
                    int totalA = ConvertTo(count.GetValue(value1, null), count.PropertyType);
                    int totalB = ConvertTo(count.GetValue(value2, null), count.PropertyType);
        
                    if (!Compare(totalA, totalB))
                        return false;
        
        
                    PropertyInfo item = typeof(T).GetProperty("Item");
                    CompareAsInumerable(value1, value2);
        
                    return true;
        
                }
        
                private bool IsGenericList(Type t)
                {
        
        
                    return t.IsGenericType && IsEnumerable(t) && t.GetProperties().Where(p => p.CanRead).Any(p => genericListPropertiesNames.Contains(p.Name));
        
                }
                [Conditional("DEBUG")]
                private void ShowInfo(PropertyInfo p)
                {
                    Debug.WriteLine(string.Format("Checkeando propiedad {0}",p.Name));
                }
        
                private bool CompareFields<T>(T value1, T value2)
                {
                    List<FieldInfo> fields = typeof(T).GetFields().Where(f => f.IsPublic).ToList();
        
                    foreach (var f in fields)
                    {
                        dynamic valueA = f.GetValue(value1);
                        dynamic valueB = f.GetValue(value2);
        
                        if (!Compare(f.GetValue(value1), f.GetValue(value2)))
                        {
                            throw new NotEqualsException(value1, value2);
                            //return false;
                        }
        
                    }
                    return true;
                }
        
        
                private bool CompareAsInumerable<T>(T valueA, T valueB)
                {
                    IEnumerable<object> colA = ((IEnumerable)valueA).Cast<object>();
                    IEnumerable<object> colB = ((IEnumerable)valueB).Cast<object>();
                    if (colA.Count() != colB.Count())
                        return false;
        
                    Type t1 = GetType(colA.GetType());
                    Type t2 = GetType(colB.GetType());
        
                    if (t1 != t2)
                        return false;
        
                    if (colA.Count() > 0)
                    {
                        Type itemType = GetTypeOfItem(colA);
        
                        for (int i = 0; i < colA.Count(); i++)
                        {
                            try
                            {
                                dynamic a = colA.ElementAt(i);
                                dynamic b = colB.ElementAt(i);
        
                                if (!Compare(a, b))
                                {
                                    throw new NotEqualsException(colA.ElementAt(i), colB.ElementAt(i));
                                    //return false;
                                }
                            }
                            catch (NotEqualsException ex)
                            {
                                ex.AddParent(itemType.Name);
                               throw ;
                            }
                        }
                    }
                    return true;
                }
        
                private Type GetTypeOfItem(IEnumerable<object> collection)
                {
        
                    if (collection == null)
                        return null;
                    Type[] t = collection.GetType().GetGenericArguments();
        
                    if ((t != null) && (t.Count() > 0))
                        return t[0];
                    return null;
        
                }
        
        
        
                private bool IsEnumerable(Type type)
                {
                    return typeof(IEnumerable).IsAssignableFrom(type);
                }
        
                private bool CompareBasic<T>(T valueA, T valueB)
                {
                    bool result;
                    IComparable selfValueComparer;
        
                    selfValueComparer = valueA as IComparable;
        
                    if (valueA == null && valueB != null || valueA != null && valueB == null)
                        result = false;
                    else if (selfValueComparer != null && selfValueComparer.CompareTo(valueB) != 0)
                        result = false;
                    else if (!object.Equals(valueA, valueB))
                        result = false;
                    else
                        result = true;
        
                    if (!result)
                        throw new NotEqualsException(valueA, valueB);
                    return result;
        
        
                }
                private bool IsBasicCompare(Type type)
                {
                    return typeof(IComparable).IsAssignableFrom(type) || type.IsPrimitive || type.IsValueType;
                }
        
        
                private Type GetType<T>()
                {
                    return GetType(typeof(T));
                }
                private Type GetType(Type t)
                {
                    Type tipo = Nullable.GetUnderlyingType(t);
                    if (tipo == null)
                        tipo = t;
                    return (tipo == null) ? t : tipo;
                }
        
        
            }
