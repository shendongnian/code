    public class Person
    {
        public string Nome {get; set;}
        public string Sobrenome {get; set;}
        public string Sexo {get; set;}
        public string Idade {get; set;}
    }
    public class Variaveis
    {
      public Person[] People {get; set;}
      public Variaveis
      {
        People = new Person[5];
      }
    }
