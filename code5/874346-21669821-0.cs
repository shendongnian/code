    public class WorkbookEngine
    {
    public static void CreateWorkbook(DataSet ds, String path)
    {
    XmlDataDocument xmlDataDoc = new XmlDataDocument(ds);
    XslTransform xt = new XslTransform();
    StreamReader reader =new StreamReader(typeof (WorkbookEngine).Assembly.GetManifestResourceStream(typeof (WorkbookEngine), “Excel.xsl”));
    XmlTextReader xRdr = new XmlTextReader(reader);
    xt.Load(xRdr, null, null);
    StringWriter sw = new StringWriter();
    xt.Transform(xmlDataDoc, null, sw, null);
    StreamWriter myWriter = new StreamWriter (path + “\\Report.xls”);
    myWriter.Write (sw.ToString());
    myWriter.Close ();
    }
    }
