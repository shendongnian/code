    class Foo
    {
        public string PropertyA { get; set; }
        public string PropertyB { get; set; }
        // ...
        public void OnTick( object sender, EventArgs e )
        {
            // logic here
        }
    }
    var f = new Foo() { PropertyA = "some stuff here",
                        PropertyB = "some more stuff here" };
    dispatcherTimer.Tick += f.OnTick;
