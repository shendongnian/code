    Response.Clear();
    Response.AddHeader("Content-Disposition", "inline; filename=filename.xls");
                            Response.ContentType = "application/vnd.ms-excel";
    
                            System.Xml.XmlDocument xslDoc = new System.Xml.XmlDocument();
                            xslDoc.Load(System.Web.HttpContext.Current.Server.MapPath("~\\App_Data\\my_xslt_template.xslt"));
    
                            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                            xmlDoc.LoadXml(ValuesDS.GetXml());
    
                            System.Xml.Xsl.XslTransform xslt = new System.Xml.Xsl.XslTransform();
                            xslt.Load(xslDoc);
    
                            using (System.IO.StringWriter writer = new System.IO.StringWriter())
                            {
                                xslt.Transform(xmlDoc, null, writer, null);
                                Response.Write(writer.ToString());
                            }
                            Response.End();
