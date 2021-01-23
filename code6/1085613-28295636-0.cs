    class Program
    {
        private static string path = "D:\\TestData.xml";
        static void Main(string[] args)
        {
            GetXMLData();
            InsertXMLData("XYZ");
        }
        private static void GetXMLData()
        {
            // try
            // {
            XDocument testXML = XDocument.Load(path);
            var students = from student in testXML.Descendants("Student")
                           select new
                           {
                               ID = Convert.ToInt32(student.Attribute("ID").Value),
                               Name = student.Element("Name").Value
                           };
            foreach (var student in students)
            {
                // Do other operations with each student object
            }
            //  }
            //catch (Exception err)
            //{
            //    MessageBox.Show(err.Message);
            //}
        }
        private static void InsertXMLData(string name)
        {
            //try
            //{
            XDocument testXML = XDocument.Load(path);
            XElement newStudent = new XElement("Student",
                                           new XElement("Name", name)
                                       );
            var lastStudent = testXML.Descendants("Student").Last();
            int newID = Convert.ToInt32(lastStudent.Attribute("ID").Value);
            newStudent.SetAttributeValue("ID", 4);
            testXML.Element("Students").Add(newStudent);
            testXML.Save(path);
            //}
            //catch (Exception err)
            //{
            //    MessageBox.Show(err.Message);
            //}
        }
        private static void UpdateXMLData(string name, int id)
        {
            //try
            //{
            XDocument testXML = XDocument.Load(path);
            XElement cStudent = testXML.Descendants("Student").Where(c => c.Attribute("ID").Value.Equals(id.ToString())).FirstOrDefault();
            cStudent.Element("Name").Value = name;
            testXML.Save(path);
            //}
            //catch (Exception err)
            //{
            //    MessageBox.Show(err.Message);
            //}
        }
    }
