    void AddPropertiesToTextbox(object output, string rootNamespace = "")
        {
            PropertyInfo[] piData = null;
            piData = Utility.GetPublicProperties2(output.GetType());
            foreach (PropertyInfo pi in piData)
            {
                if (pi.PropertyType.IsArray == true)
                {
                    Array subOutput = (Array)pi.GetValue(output);
                    
                    for (int i = 0; i < subOutput.Length; i++)
                    {
                        textResult.Text += string.Format("{0}------------------------{0}", Environment.NewLine);
                        object o = subOutput.GetValue(i);
                        AddPropertiesToTextbox(o, pi.Name);
                    }
                }
                else
                {
                    if (pi.Name.ToLower() != "extensiondata")
                    {
                        if (string.IsNullOrWhiteSpace(rootNamespace) == false) {
                            textResult.Text += string.Format("{2}.{0}: '{1}'", pi.Name, pi.GetValue(output, null), rootNamespace);
                        textResult.Text += Environment.NewLine;
                        } else {
                            textResult.Text += string.Format("{0}: '{1}'", pi.Name, pi.GetValue(output, null));
                        textResult.Text += Environment.NewLine;
                        }
                        
                    }
                }
            }
        }
