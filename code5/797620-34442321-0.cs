    public class Person
    {
        public string Name { get; set; }
        public string PhNo { get; set; }
    }
    public class Company
    {
        public int EmpNo { get; set; }
        public string Title { get; set; }
    }
    public class PersonCompany
    {
        public string Name { get; set; }
        public string PhNo { get; set; }
        public int EmpNo { get; set; }
        public string Title { get; set; }
    }
    //you can test as below
            var pMap = Mapper.CreateMap<Person,PersonCompany>();
            pMap.ForAllMembers(d => d.Ignore()); 
            pMap.ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.PhNo, opt => opt.MapFrom(s => s.PhNo));
            var cMap = Mapper.CreateMap<Company, PersonCompany>();
            cMap.ForAllMembers(d => d.Ignore());
            cMap.ForMember(d => d.EmpNo, opt => opt.MapFrom(s => s.EmpNo))
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title));
            var person = new Person { Name = "PersonName", PhNo = "212-000-0000" };
            var personCompany = Mapper.Map<Person,PersonCompany>(person);
            var company = new Company { Title = "Associate Director", EmpNo = 10001 };
            personCompany = Mapper.Map(company, personCompany);
            Console.WriteLine("personCompany.Name={0}", personCompany.Name);
            Console.WriteLine("personCompany.PhNo={0}", personCompany.PhNo);
            Console.WriteLine("personCompany.EmpNo={0}", personCompany.EmpNo);
            Console.WriteLine("personCompany.Title={0}", personCompany.Title);
