    public class BaseModel{
        List<string> AuthRoles {get;set;}
        public BaseModel(List<string> authorisedRoles){
            AuthRoles = authorisedRoles;
        }
        public BaseModel(){
             AuthRoles = new List<string>();
        }
    }
