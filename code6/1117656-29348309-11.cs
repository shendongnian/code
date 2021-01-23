    namespace Wobbles
    {
        public class TestViewModel
        {
            public TestViewModel()
            {
                Menu = CreateMenu();
            }
            public Wobbles.ApplicationMenuItem Menu { get; protected set; }
            protected Wobbles.ApplicationMenuItem CreateMenu()
            {
                var m = new Wobbles.ApplicationMenuItem("Menu");
                var msub = new Wobbles.ApplicationMenuItem("Submenu");
                msub.Items.Add(new Wobbles.ApplicationMenuItem("Sub Sub 1"));
                msub.Items.Add(new Wobbles.ApplicationMenuItem("Sub Sub 2"));
                //  LOL
                msub.Items.Add(msub);
                m.Items.Add(msub);
                m.Items.Add(new Wobbles.ApplicationMenuItem("Foo"));
                m.Items.Add(new Wobbles.ApplicationMenuItem("Bar"));
                m.Items.Add(new Wobbles.ApplicationMenuItem("Baz"));
                return m;
            }
        }
    }
