    public class Person
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string User_Name { get; set; }
    }
    List<Person> people = AutoMapper.Mapper.DynamicMap<IDataReader, List<Person>>(sourceDataTable.CreateDataReader());
