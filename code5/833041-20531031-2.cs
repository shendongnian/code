     dynamic values = TypeDescriptor.GetAttributes(myExpando);
                for (int i = 0; i < values.Count; i++)
                {
                    System.Console.WriteLine(values[i]);
                }
