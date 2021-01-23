    public class School{
        private IPerson _director;
        public School(IPersonFactory factory){
           _director = factory.CreateDirector();
        }
    }
    public class Building{
        private IPerson _administrator;
        public Building(IPersonFactory factory){
           _administrator = factory.CreateAdministrator();
        }
    }
