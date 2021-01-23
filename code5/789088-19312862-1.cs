    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using System.Xml.Linq;
    
    namespace XamlLoad
    {
        class Program
        {
            static void Main(string[] args)
            {
                string file = @"<Window x:Class=""WpfApplication1.MainWindow""
            xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
            xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
            Title=""MainWindow"" Height=""350"" Width=""525"">
        <Grid x:Name=""Content"">
    
    
        </Grid>
    </Window>";
    
                var doc = XDocument.Load(new StringReader(file));
                XNamespace xmlns = "http://schemas.microsoft.com/winfx/2006/xaml/presentation";
                XNamespace x = "http://schemas.microsoft.com/winfx/2006/xaml";
                var gridElement = doc.Root.Elements(xmlns + "Grid").Where(p => p.Attribute(x + "Name") != null && p.Attribute(x + "Name").Value == "Content");
            }
        }
    }
