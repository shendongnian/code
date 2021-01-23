    public class MyOfficeService
    {
        private readonly IOfficeRepository officeRepostiory;
        public MyOfficeService(IOfficeRepository repository)
        {
            this.officeRepostiory = repository;
        }
        public Office GetOffice(int id)
        {
            return this.officeRepostiory.GetAll().SingleOrDefault(o => o.Id == id);
        }
    }
