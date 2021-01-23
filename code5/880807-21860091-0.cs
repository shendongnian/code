    public interface IPerson
    {
        ValueType InnerID { get; }
    }
    public abstract class Person<T> : IPerson
        where T : struct
    {
        public T ID { get; set; }
        protected abstract ValueType InnerID { get; }
        ValueType IPerson.InnerID { get { return InnerID; } }
    }
    public class Student : Person<byte>
    {
        protected override ValueType InnerID
        {
            get { return ID; }
        }
    }
    public class Adult : Person<short>
    {
        protected override ValueType InnerID
        {
            get { return ID; }
        }
    }
    public class StudentRegistered
    {
        public ValueType StudentID { get { return Person.InnerID; } }
        public IPerson Person { get; set; }
        public int EventId { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var A=new Student() { ID=100 }; // byte
            var B=new Adult() { ID=1000 };  // short
            var regA=new StudentRegistered() { Person=A };
            Console.WriteLine("Type: {0} Value: {1}", regA.StudentID.GetType().Name, regA.StudentID);
            // Type: Byte Value: 100
            var regB=new StudentRegistered() { Person=B };
            Console.WriteLine("Type: {0} Value: {1}", regB.StudentID.GetType().Name, regB.StudentID);
            // Type: Int16 Value: 1000
        }
    }
