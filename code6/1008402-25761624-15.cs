        public interface IClass1 { string MyVar { get; set; } }
        public interface IClass2 : IClass1 { new string MyVar { get; set; } }
        public class Class1 : IClass1
        {
            string IClass1.MyVar { get; set; }
        }
        public class Class2 : IClass2
        {
            string IClass1.MyVar { get; set; }
            string IClass2.MyVar { get; set; }
        }
