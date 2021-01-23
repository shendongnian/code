    public static class Database
    {
        static AVLTree<Country> countries = new AVLTree<Country>();
    
        static Database()
        {
    
        }
    
        static AVLTree<Country> cees()
        {
            return countries;
        }
    
        public static AVLTree<Country> Countries
        {
            get { return countries; }
        }
    }
