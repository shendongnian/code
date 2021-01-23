    using System.Diagnostics;
    using System.Xml;
    using System.Xml.Xsl;
    
    namespace ConsoleApplication1
    {
      class Program
      {
        private const string XML_FILE = @"Documents\ltcstops.xml";
        private const string XSLT_FILE_IN = @"Documents\ltcstops.xslt";
        private const string HTML_FILE_OUT = @"Documents\ltcstops.html";
    
        static void Main(string[] args)
        {
          // Create the XslCompiledTransform and load the stylesheet.
          XslCompiledTransform xslt = new XslCompiledTransform();
          xslt.Load(XSLT_FILE_IN);
    
          // Create the XsltArgumentList.
          XsltArgumentList xslArg = new XsltArgumentList();
    
          // Create a parameter which represents the current date and time.
          string streetName = "Adelaide & Ada NB";
          xslArg.AddParam("theStreet", "", streetName);
    
          // Transform the file. 
          using (XmlWriter w = XmlWriter.Create(HTML_FILE_OUT))
          {
            xslt.Transform(XML_FILE, xslArg, w);
          }
    
          Process proc = new System.Diagnostics.Process();
          proc.StartInfo.FileName = "iexplore";
          proc.StartInfo.Arguments = HTML_FILE_OUT;
          proc.Start();
        }
      }
    }
