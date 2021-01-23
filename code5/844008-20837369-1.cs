    public class HomeController: AsyncController
    {
        public void IndexAsync()
        {
            AsyncManager.OutstandingOperations.Increment(3);
            BeginGetFooFromDbAsynchronously(foo => 
            {
                AsyncManager.Parameters["foo"] = foo;
                AsyncManager.OutstandingOperations.Decrement(1);
            });
            BeginGetBarFromDbAsynchronously(bar => 
            {
                AsyncManager.Parameters["bar"] = bar;
                AsyncManager.OutstandingOperations.Decrement(1);
            });
            BeginGetBazFromDbAsynchronously(baz => 
            {
                AsyncManager.Parameters["baz"] = baz;
                AsyncManager.OutstandingOperations.Decrement(1);
            });
        }
        public ActionResult IndexCompleted(Foo foo, Bar bar, Baz baz) 
        {
            MyViewModel model = new MyViewModel(); 
            model.Foo = foo;
            model.Bar = bar;
            model.Baz = baz;
            return View(model);
        }
    }
