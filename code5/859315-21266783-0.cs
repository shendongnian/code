    public class Form1 : ...
    {
        public Proizvod Foo;
    
        Form1()
        {
            Foo = new Proizvod();
        }
    
        SomeMethod()
        {
            MessageBox.Show(Foo.Naziv);
        }
    }
