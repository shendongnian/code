    public class Student
    {
         public override string ToString()
         {
              return JsonConvert.Serialize(this);
         }
    }
