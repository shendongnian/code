    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.IO;
    namespace SOAPonFHIR.Test
    {
        [TestClass]
        public class Schematron
        {
            [TestMethod]
            public void XSLT_SAXON_Simple_Schematron2()
            {
    
                ///////////////////////////////
                // Transform original Schemtron  
                ///////////////////////////////
                string path = AppDomain.CurrentDomain.BaseDirectory;
    
                Uri schematron = new Uri(@"file:\\" + path + @"\simple\input.sch");
                Uri schematronxsl = new Uri(@"file:\\" + path + @"\xsl_2.0\iso_svrl_for_xslt2.xsl");
    
                Stream schematrontransform = new Test.XSLTransform().Transform(schematron, schematronxsl);
    
                ///////////////////////////////
                // Apply Schemtron xslt 
                ///////////////////////////////
                FileStream xmlstream = new FileStream(path + @"\simple\input.xml", FileMode.Open, FileAccess.Read, FileShare.Read);
                Stream results = new Test.XSLTransform().Transform(xmlstream, schematrontransform);
    
                System.Diagnostics.Debug.WriteLine("RESULTS");
                results.Position = 0;
                System.IO.StreamReader rd2 = new System.IO.StreamReader(results);
                string xsltSchematronResult = rd2.ReadToEnd();
                System.Diagnostics.Debug.WriteLine(xsltSchematronResult);
    
            }
        }
    }
