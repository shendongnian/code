using System.Reflection;
public static object CreateInstance(string typeName, string assemblyName)
{
    object result = null;
    try
    {
        Assembly assembly = Assembly.Load(assemblyName);
        Type type = assembly.GetType(typeName, true, false);
        result = Activator.CreateInstance(type);
    }
    catch (Exception ex)
    {
        //Handle exception here
    }
    if (result == null)
    {
        //Can handle null here
    }
    return result;
}
