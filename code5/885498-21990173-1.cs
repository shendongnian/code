    public partial class MyBaseClass
    {
        public void DoMyWork()
        {
            (new MySubClass1()).DoSubClass1();
            (new MySubClass2()).DoSubClass2();
        }
    }
