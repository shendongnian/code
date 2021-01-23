    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Xml;
    using System.Xml.XPath;
    using System.Xml.Xsl;
    using Saxon.Api;
    using System.IO;
    using System.Xml.Schema;
    using System.Collections.Generic;
    
    namespace SOAPonFHIR.Test
    {
        public class XSLTransform
        {
            public Stream Transform(Uri xmluri, Uri xsluri)
            {
    
    
                // Create a Processor instance.
                Processor processor = new Processor();
    
                // Load the source document
                XdmNode input = processor.NewDocumentBuilder().Build(xmluri);
    
                // Create a transformer for the stylesheet.
                var compiler = processor.NewXsltCompiler();
                compiler.ErrorList = new System.Collections.Generic.List<Exception>();
    
                XsltTransformer transformer = compiler.Compile(xsluri).Load();
    
                if (compiler.ErrorList.Count != 0)
                    throw new Exception("Exception loading xsl!");
    
                // Set the root node of the source document to be the initial context node
                transformer.InitialContextNode = input;
    
                // Create a serializer
                Serializer serializer = new Serializer();
                MemoryStream results = new MemoryStream();
                serializer.SetOutputStream(results);
    
                // Transform the source XML to System.out.
                transformer.Run(serializer);
    
                //get the string
                results.Position = 0;
                return results;
    
    
            }
    
            public System.IO.Stream Transform(System.IO.Stream xmlstream, System.IO.Stream xslstream)
            {
    
                // Create a Processor instance.
                Processor processor = new Processor();
    
                // Load the source document
                var documentbuilder = processor.NewDocumentBuilder();
                documentbuilder.BaseUri = new Uri("file://c:/" );
                XdmNode input = documentbuilder.Build(xmlstream);
    
                // Create a transformer for the stylesheet.
                var compiler = processor.NewXsltCompiler();
                compiler.ErrorList = new System.Collections.Generic.List<Exception>();
                compiler.XmlResolver = new XmlUrlResolver();
                XsltTransformer transformer = compiler.Compile(xslstream).Load();
    
                if (compiler.ErrorList.Count != 0)
                    throw new Exception("Exception loading xsl!");
    
                // Set the root node of the source document to be the initial context node
                transformer.InitialContextNode = input;
    
                // Create a serializer
                Serializer serializer = new Serializer();
                MemoryStream results = new MemoryStream();
                serializer.SetOutputStream(results);
    
                // Transform the source XML to System.out.
                transformer.Run(serializer);
    
                //get the string
                results.Position = 0;
                return results;
    
    
            }
    
        }
    }
