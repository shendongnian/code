     foreach (PropertyInfo prop in response.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
                {
                    object value = prop.GetValue(response, new object[] { });
                    Console.WriteLine("{0} = {1}", prop.Name, value);
                }
