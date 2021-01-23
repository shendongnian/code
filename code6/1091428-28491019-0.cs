            string GetProperty(Worksheet ws, string name)
            {            
                foreach (CustomProperty cp in ws.CustomProperties)
                    if (cp.Name == name)
                        return cp.Value;
                return null;
            }
            void SetProperty(Worksheet ws, string name, string value)
            {            
                bool found = false;
                CustomProperties cps = ws.CustomProperties;
                foreach (CustomProperty cp in cps)
                {
                    if (cp.Name == name)
                    {
                        found = true;
                        cp.Value = value;
                    }
                }
                if (!found)
                    cps.Add(name, value);       
            }
