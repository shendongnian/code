    class Program
    {
        static void Main(string[] args)
        {
            DelClass MyDel = new DelClass();
            Functions MyTster = new Functions();
            DelClass.StrDelegate Name = new DelClass.StrDelegate(MyTster.MyFname);
            MyTster.MyFnameProperty ="SomeVariableName";
            DelClass.StrDelegate Family = new DelClass.StrDelegate(MyTster.MyLname);
            MyTster.MyLnameProperty = "SomeVariableFamilyName";
            MyDel.StringCon(Name, Family);
        }
    }
