    public class Person{
      public string Name {get;set;}
    }
    public interface IPersonRepository{
      void AddPerson(Person p);
    } 
    public class PersonRepository{
      public void AddPerson(Person p){
        using(var connection = new MySqlConnection("some connection string"){
          connection.Open();
          var command  = new MySqlCommand(connection);
          command.Text = string.Format("insert into Person (Name) values ({0})", p.Name)l
          command.ExecuteNonQuery();
        }
    
      }
    }
