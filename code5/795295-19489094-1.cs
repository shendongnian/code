        public class MyDataModels
        {
            LookUpData MysetOfData { get; set; }
            int MyVal { get; set; }
        }
        public  class MyCar
        {
            public int ID { get; set; }
            [Searchable]
            public string Model { get; set; }
            public int ManufactureId { get; set; }
            public MyDataModels MyModel { get; set; }
        }
        
