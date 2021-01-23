    namespace Generics
{
     
    public class Dog
    {
        public string Breed { get; set; }
        public string Name { get; set; }
        public int legs { get; set; }
        public bool tail { get; set; }   
    }
    public class Cat
    {
        public string Breed { get; set; }
        public string Name { get; set; }
        public int toes { get; set; }
        public bool Aggressive { get; set; }
        public bool tail { get; set; }
    }
     
   
    class Program
    {
        
        public static DataTable CreateDataTable(Type animaltype)
        {
            
            DataTable return_Datatable = new DataTable();
            foreach (PropertyInfo info in animaltype.GetProperties())
            {
                return_Datatable.Columns.Add(new DataColumn(info.Name, info.PropertyType));
            }
            return return_Datatable;
        }
       
        public static DataRow makeRow(object input, DataTable table)
        {
            Type inputtype = input.GetType();
            DataRow row = table.NewRow();
            foreach (PropertyInfo info in inputtype.GetProperties())
            {
                row[info.Name] = info.GetValue(input, null);
            }
            return row;
        }
        static void Main(string[] args)
        {
            Cat Dexter = new Cat();
            Dexter.Breed = "Bengal";
            Dexter.toes = 12;
            Dexter.tail = false;
            Dexter.Name = "Killer";
            Dexter.Aggressive = true;
            Dog Killer = new Dog();            
            Killer.Breed = "Maltese Poodle";
            Killer.legs = 3;
            Killer.tail = false;
            Killer.Name = "Killer";       
            DataTable dogTable = CreateDataTable(typeof(Dog));
            dogTable.Rows.Add(makeRow(Killer, dogTable));
            DataTable catTable = CreateDataTable(typeof(Cat));
            catTable.Rows.Add(makeRow(Dexter, catTable));
            foreach (DataRow rows in catTable.Rows)
            {
                foreach (DataColumn col in catTable.Columns)
                {
                    Console.WriteLine("Column {0} =" + rows[col].ToString(), col.ColumnName.PadRight(15));
                }
            }
            foreach (DataRow rows in dogTable.Rows)
            {
                foreach (DataColumn col in dogTable.Columns)
                {
                    Console.WriteLine("Column {0} =" + rows[col].ToString(),col.ColumnName.PadRight(15));
                }
            }
            Console.ReadLine();
            
        }      
    }
