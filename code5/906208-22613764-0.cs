    public MainWindow()
    {
        // ...
        DG1.ContextMenu = Menus.Context_Menus.generate_datagrid_context_menu();
    }
    namespace Menus
    {
        public static class Context_Menus
        {
            public static ContextMenu generate_datagrid_context_menu()
            {
                ContextMenu cm = new ContextMenu();
                MenuItem mi1 = new MenuItem();
                mi1.Header = "Test1";
                cm.Items.Add(mi1);
                return cm;
            }
        }
    }
