        public class building // Building Object Class
        {
            protected virtual int Size{ get;}
            private int[,] Cells; 
            public int[,] create() 
            {
                Cells = new int[Size, Size]; 
                return Cells;
             }
        }
        public class Room
        {
            protected virtual int Size
            {
                 get
                 {
                     // return custom value here
                 }
            }
        }
