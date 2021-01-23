    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace Settings
    {
        public class ConfigProperties
        {
            public class PropertyList<T> : List<ConfigProperty>
            {
                public ConfigProperty this[String propertyName]
                {
                    get
                    {
                        ConfigProperty ret = null;
                        foreach (ConfigProperty cp in this)
                        {
                            if (cp.Name == propertyName)
                            {
                                ret = cp;
                                break;
                            }
                        }
                        return ret;
                    }
                    set
                    {
                        ConfigProperty ret = null;
                        foreach (ConfigProperty cp in this)
                        {
                            if (cp.Name == propertyName)
                            {
                                ret = cp;
                                break;
                            }
                        }
                        value = ret;
                    }
                }
                public PropertyList()
                    : base()
                {
    
                }
    
                public void Add(String Name, String Value)
                {
                    ConfigProperty cp = new ConfigProperty();
                    cp.Name = Name;
                    cp.Value = Value;
                    this.Add(cp);
                }
            }
            public class ConfigProperty
            {
                public String Name { get; set; }
                public String Value { get; set; }
                public ConfigProperty()
                {
                    Name = "newPropertyName_" + DateTime.Now.Ticks.ToString();
                    Value = "";
                }
                public ConfigProperty(String name, String value)
                {
                    Name = name;
                    Value = value;
                }
            }
    
            public String FileName { get; set; }
            public PropertyList<ConfigProperty> CFCollection { get; private set; }
    
            public ConfigProperties()
                : this(AppDomain.CurrentDomain.BaseDirectory + "config.ini")
            {
            }
    
            public ConfigProperties(String fileName)
            {
                CFCollection = new PropertyList<ConfigProperty>();
                FileName = fileName;
                if (fileName != null && File.Exists(fileName))
                {
                    ReadFile();
                }
            }
    
            private void ReadFile()
            {
                if (File.Exists(FileName))
                {
                    CFCollection = new PropertyList<ConfigProperty>();
                    using (StreamReader sr = new StreamReader(FileName, Encoding.Default))
                    {
                        while (!sr.EndOfStream)
                        {
                            String line = sr.ReadLine();
                            if (!line.StartsWith("#"))
                            {
                                ConfigProperty cf = new ConfigProperty();
                                String tmp = "";
                                Char splitter = '=';
                                for (int i = 0; i < line.Length; i++)
                                {
                                    if (line[i] != splitter)
                                    {
                                        tmp += ((Char)line[i]).ToString();
                                    }
                                    else
                                    {
                                        cf.Name = tmp;
                                        tmp = "";
                                        splitter = '\n';
                                    }
                                }
                                cf.Value = tmp;
                                if (cf.Name.Length > 0)
                                {
                                    CFCollection.Add(cf);
                                }
                            }
                        }
    
                        sr.Close();
                    }
                }
            }
    
            private void SaveConfigProperty(ConfigProperty prop)
            {
                List<String> output = new List<String>();
                if (File.Exists(FileName))
                {
                    using (StreamReader sr = new StreamReader(FileName, Encoding.Default))
                    {
                        while (!sr.EndOfStream)
                        {
                            String line = sr.ReadLine();
                            if (line.StartsWith(prop.Name + "="))
                            {
                                output.Add(prop.Name + "=" + prop.Value);
                            }
                            else
                            {
                                output.Add(line);
                            }
                        }
                        sr.Close();
                    }
                }
    
                if (!output.Contains(prop.Name + "=" + prop.Value))
                {
                    output.Add(prop.Name + "=" + prop.Value);
                }
    
                StreamWriter sw = new StreamWriter(FileName, false, Encoding.Default);
    
                foreach (String s in output)
                {
                    sw.WriteLine(s);
                }
                sw.Close();
                sw.Dispose();
                GC.SuppressFinalize(sw);
                sw = null;
    
                output.Clear();
                output = null;
    
            }
    
            public void Save()
            {
                foreach (ConfigProperty cp in CFCollection)
                {
                    SaveConfigProperty(cp);
                }
            }
    
            public void UpdateValue(String propertyName, String propertyValue)
            {
                try
                {
                    IEnumerable<ConfigProperty> myProps = CFCollection.Where(cp => cp.Name.Equals(propertyName));
                    if (myProps.Count() == 1)
                    {
                        myProps.ElementAt(0).Value = propertyValue;
                    }
                    else if (myProps.Count() == 0)
                    {
                        CFCollection.Add(new ConfigProperty(propertyName, propertyValue));
                    }
                    else
                    {
                        throw new Exception("Can't find/set value for: " + propertyName);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
    
            public String ToString(String propertyName)
            {
                try
                {
                    return CFCollection.Where(cp => cp.Name.Equals(propertyName)).First().Value;
                }
                catch (Exception ex)
                {
                    throw new Exception("Can't find/read value for: " +
                        propertyName, ex);
                }
            }
    
        }
    }
