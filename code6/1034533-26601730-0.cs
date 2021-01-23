    public partial class  Test : Page
    {
        Derivedclass D = new Derivedclass();
        public Test()
        {
            Calculate();
        }     
    
        public void Calculate()
        {
    
            for(int i =1; i <5 ;i++)
            {
                D.ID = i;
                for (int j = 0; j < 5; j++)
                {
                    D.X = j;
                    D.Y = j;
                }
                MessageBox.Show("ID " + D.ID + " Total Sum" + D.Total);
                D.Total = 0;
            }
        }
        // Out put should be 
        // ID 1 Total Sum 16
        // ID 2 Total Sum 16
        // ID 3 Total Sum 16
        // ID 4 Total Sum 16
    }
