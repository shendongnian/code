    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace repofT
    {
    class Program
    {
        static void Main(string[] args)
        {
            // Kick Start Repository of T demo
            // There are advance models combining context creation / unit of work and repository.
            // The concept of Inversion of Control / Dependency injection should be inestigated
            // for the people new to IOC
            // SIMPLIFIED Unit of Work and Respository of T sample
            var ctx = new MyContext();
            var uow = new UnitOfWork(ctx);
            var rep = new Repository<MyPoco>(ctx);
            addTest(rep, uow);
            
            var poco1 = FindTest(rep);
            ChangeTest(poco1, rep, uow);
            Console.ReadKey();
        }
        private static void ChangeTest(MyPoco poco1, Repository<MyPoco> rep, UnitOfWork uow)
        {
            poco1.Content = "Test - was changed";
            rep.Change(poco1);
            uow.Commit();
            DumpTest(rep);
        }
        private static MyPoco FindTest(Repository<MyPoco> rep)
        {
            var poco1 = rep.Find(1);
            Console.WriteLine(poco1.Id + " : " + poco1.Content);
            return poco1;
        }
        private static void addTest(Repository<MyPoco> rep, UnitOfWork uow)
        {
            var mypoco = new MyPoco()
            {
                Content = "Test" + System.DateTime.Now.ToString(CultureInfo.InvariantCulture),
            };
            rep.Add(mypoco);
            uow.Commit();
            DumpTest(rep);
        }
        private static void DumpTest(Repository<MyPoco> rep)
        {
            var pocoList = rep.GetList(t => t.Content.StartsWith("Test"));
            if (pocoList != null)
            {
                foreach (var poco in pocoList)
                {
                    Console.WriteLine(poco.Id + " : " + poco.Content);
                }
            }
        }
    }
    }
