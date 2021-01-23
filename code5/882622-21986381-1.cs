    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    
    namespace WpfApplication1
    {
        public class MyNode
        {
            public MyNode()
            {
                Items = new ObservableCollection<MyNode>();
                Property1 = "P1";
                Property2 = "P1";
            }
    
            public string Name { get; set; }
    
            public bool IsLeafNode { get; set; }
    
            [DisplayName("Property 1")]
            public string Property1 { get; set; }
    
            [DisplayName("Property 2")]
            public string Property2 { get; set; }
    
            public ObservableCollection<MyNode> Items { get; set; }
    
            public IEnumerable<MyNode> Properties
            {
                get
                {
                    var list = new List<MyNode>();
                   
    
                    if (IsLeafNode)
                    {
                        var nameBuffer = new StringBuilder();
    
                        Type type = new MyNode().GetType();
    
                        foreach (PropertyInfo pInfo in type.GetProperties())
                        {
                            DisplayNameAttribute attr = (DisplayNameAttribute)Attribute.GetCustomAttribute(pInfo, typeof(DisplayNameAttribute));
    
                            if (attr != null)
                            {
                                list.Add(new MyNode() { Name = attr.DisplayName.ToString() });
                              
                            }
                        }
                    
                    }
                    return list;
                }
            }
    
        }
    }
