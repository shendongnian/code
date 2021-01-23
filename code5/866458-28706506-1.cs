     if (values != null && values.Count() > 0)
            {
                // iterate through the filters and assign variables as required
                foreach (var kvp in values)
                {
                    switch (kvp.Key.ToUpper())
                    {
                        case "col1":
                            col1 = kvp.Value.ToString();
                            break;
                        case "col2":
                            col2 = kvp.Value.ToString();
                            break;
                        case "col3":
                            col3 = Convert.ToInt32(kvp.Value);
                            break;
                        default: break;
                    }
                }
            }
