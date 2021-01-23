    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication1
    {
    class Program
    {
        static void Main(string[] args)
        {
            var data = new List<myData>();
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Geef de naam : ");
                var naam = Console.ReadLine();
                Console.Write("Geef de leeftijd : ");
                var leeftijd = Convert.ToInt32(Console.ReadLine());
                data.Add(new myData(naam, leeftijd));
            }
            Console.WriteLine("De namen zijn  " + data.Count().ToString());
            Console.WriteLine();
            data.ForEach(delegate(myData d)
            {
                Console.WriteLine("De naam is : " + d.name + " De leftijd is : " + d.age);
                //or better way
                Console.WriteLine("De naam is : {0}\tDe leftijd is : {1}", d.name, d.age);
            });
            Console.ReadLine();
        }
    }
    public class myData
    {
        public string name { get; set; }
        public int age { get; set; }
        public myData(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }
    }
