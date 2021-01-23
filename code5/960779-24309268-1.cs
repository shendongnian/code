    using System;
    using System.Xml.Linq;
    
    class Test
    {
        static void Main()
        {
            XDocument doc = XDocument.Load("test.xml");
            // All elements with an empty namespace...
            foreach (var node in doc.Root.Descendants()
                                    .Where(n => n.Name.NamespaceName == ""))
            {
                 // Remove the xmlns='' attribute. Note the use of
                 // Attributes rather than Attribute, in case the
                 // attribute doesn't exist (which it might not if we'd
                 // created the document "manually" instead of loading
                 // it from a file.)
                 node.Attributes("xmlns").Remove();
                 // Inherit the parent namespace instead
                 node.Name = node.Parent.Name.Namespace + node.Name.LocalName;
            }
            Console.WriteLine(doc); // Or doc.Save(...)
        }
    }
