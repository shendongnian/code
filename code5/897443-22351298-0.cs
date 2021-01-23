    public class MyEnum
    {
        public int Code
        {
            get; set;
        }
        public int Info
        {
            get; set;
        }
    
        public string Display()
        {
            Console.WriteLine(this.Code);
            Console.WriteLine(this.Info)
        }
    
        //
        // This will keep your enums static, available from any method
        //
        private static List<MyEnum> _globals = new List<MyEnum();
    
        public static List<MyEnum> Globals ()
        {
            if (this._globals.Count == 0)
            {
                this._globals.Add(new MyEnum(){ Code = 1, Info = 3 });
                this._globals.Add(new MyEnum(){ Code = 91, Info = 4 });
                this._globals.Add(new MyEnum(){ Code = 6, Info = 27 });
            }
            
            return this._globals;
        }
    }
