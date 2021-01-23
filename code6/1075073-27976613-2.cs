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
