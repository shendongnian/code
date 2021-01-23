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
                m.Items.Add(new Wobbles.ApplicationMenuItem("Foo"));
                m.Items.Add(new Wobbles.ApplicationMenuItem("Bar"));
                m.Items.Add(new Wobbles.ApplicationMenuItem("Baz"));
                return m;
            }
        }
    }
