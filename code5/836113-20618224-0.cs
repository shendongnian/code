    public class LoadXML
    {
        static public void LoadData(group LoadInfo)
        {
            XmlSerializer xs = new XmlSerializer(LoadInfo.GetType());
            TextReader Read = new StreamReader("dataxml.xml");
            List<Employees> GroupList;
            GroupList = (List<Employees>)xs.Deserialize(Read);
           // Now you have an array of Employees - but why do you need it. you have already a list class. it's verymuch flexible to implement a List class
            Employee [] employeeArray = GroupList.ToArray();
        }
    }
