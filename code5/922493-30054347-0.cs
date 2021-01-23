    public class UserInformation {
       public string Name { get; set; }
       public int Age { get; set; }
       
       public UserInformation(UserEntity user) {
          this.Name = user.name;
          this.Age = user.age;
       }
    }
