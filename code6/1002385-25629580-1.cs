    namespace MyNamespace {
        public class CustomClass0 : IExcelQueryable {
            public double myNumber { get; set; }
            public string myString { get; set; }
            public void BuildFrom(object[] data) {
                myNumber = (double)data[0];
                myString = (string)data[1];
            }
        }
    }
