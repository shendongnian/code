    public static class TestXmlDoctor
    {
        public static void TestFix()
        {
            string xml1 = @"<?xml version=""1.0"" encoding=""UTF-8""?>
    <MainClass>
    <PrintStatus>N</PrintStatus>
    <CustomerPO> >>>> pearl <<<<< </CustomerPO>
    <Description>PO# pearl</Description>
    <BranchID>4</BranchID>
    <PostDate>
       <Date>01/13/2015</Date>
    </PostDate>
    <ShipDate>
       <Date>01/13/2015</Date>
    </ShipDate>
    </MainClass>
    ";
            XName[] childlessNodes1 = new XName[] 
            {
                XName.Get("CustomerPO", string.Empty),
            };
            try
            {
                TestFix(xml1, childlessNodes1);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        public static string TestFix(string xml, IEnumerable<XName> childlessNodes)
        {
            string fixedXml;
            var status = (new XmlDoctor(xml, childlessNodes).TryFix(out fixedXml));
            switch (status)
            {
                case XmlDoctorStatus.NoFixNeeded:
                    return xml;
                case XmlDoctorStatus.FixFailed:
                    Debug.WriteLine("Failed to fix xml");
                    return xml;
                case XmlDoctorStatus.FixMade:
                    Debug.WriteLine("Fixed XML, new XML is as follows:");
                    Debug.WriteLine(fixedXml);
                    Debug.WriteLine(string.Empty);
                    return fixedXml;
                default:
                    Debug.Assert(false, "Unknown fix status " + status.ToString());
                    return xml;
            }
        }
    }
