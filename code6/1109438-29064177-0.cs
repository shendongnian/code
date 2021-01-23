    class MyContextMenu : ContextMenu {
        public MyContextMenu(MenuItem[] items) : base(items) { }
        ~MyContextMenu() {
            Console.WriteLine("Oops");
        }
    }
