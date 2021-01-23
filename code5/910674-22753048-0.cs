    using System.Collections.Generic;
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> sts = new List<Student>();
            Student st = null;
            Console.WriteLine("Enter Records");
            for (int i = 0; i < 3; i++)
            {
                st = new Student();
                Console.WriteLine("Enter roll");
                st.roll = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter name");
                st.name = Console.ReadLine();
                Console.WriteLine("Enter course");
                st.course = Console.ReadLine();
                sts.Add(st);
            }
    
            Console.WriteLine("Show Records");
            for (int i = 0; i < sts.Count; i++)
            {
                Console.WriteLine("Roll "+sts[i].roll.ToString());
                Console.WriteLine("Name "+sts[i].name);
                Console.WriteLine("Course "+sts[i].course);
            }
    
            Console.ReadKey();
        }
    }
    class Student 
    {
       public int roll;
       public string name;
       public string course;
    }
