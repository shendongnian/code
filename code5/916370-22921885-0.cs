    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(test("", "Something").ToString());
                Console.WriteLine(test("something", null, "blah").ToString());
                Console.WriteLine(test("something", "blah", "blah").ToString());
                Console.ReadLine();
            }
            public static bool test(string a, string b)
            {
                if (Validator.isNullOrEmpty(MethodBase.GetCurrentMethod(), a, b))
                    return false;
                return true;
            }
            public static bool test(string a, string b, string c)
            {
                if (Validator.isNullOrEmpty(MethodBase.GetCurrentMethod(), a, b, c))
                    return false;
                return true;
            }
        }
        class Validator
        {
            public static bool isNullOrEmpty(MethodBase method, params object[] values)
            {
                ParameterInfo[] pars = method.GetParameters();
                bool ret = false;
                for(var i = 0; i < pars.Length; i++)
                {
                    ParameterInfo p = pars[i];
                    string type = p.ParameterType.ToString().ToLower();
                    try
                    {
                        switch (type)
                        {
                            case "system.string":
                                ret = String.IsNullOrEmpty((string)values[i]);
                                break;
                            case "system.int32":
                            case "system.double":
                            default:
                                ret = values[i] != null;
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(String.Format("Method: {0}, Parameter: {1} has an incorrect value for a {2} with '{3}'",
                            method.Name, p.Name, type, values[i]));
                        Console.WriteLine(ex.Message);
                        return true;
                    }
                    if (ret)
                    {
                        Console.WriteLine(String.Format("Method: {0}, Parameter: {1} has a null value", method.Name, p.Name));
                        return ret;
                    }
                }
                return ret;
            }
        }
    }
