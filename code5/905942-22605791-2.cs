    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using  System.Windows.Markup;
    
        namespace AmpelThingy
        {
            class AnyClassName
            {
        		public class Save()
        		{
        			StringBuilder outstr = new StringBuilder();
        
        			XmlWriterSettings settings = new XmlWriterSettings();
        			settings.Indent = true;
        			settings.OmitXmlDeclaration = true;
        			settings.NewLineOnAttributes = true;
        
        
        			XamlDesignerSerializationManager dsm = new XamlDesignerSerializationManager(XmlWriter.Create(outstr, settings));
        			dsm.XamlWriterMode = XamlWriterMode.Expression;
        
        			XamlWriter.Save(wrapPanel1, dsm);
        			string savedControls = outstr.ToString();
        
        			File.WriteAllText(@"AA.xaml", savedControls);
        		}
            }
        }
