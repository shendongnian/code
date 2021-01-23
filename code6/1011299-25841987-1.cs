    public static class CurrentGrid
    {
        private static readonly Grid g;
        static CurrentGrid()
        {
            //Do Grid things her
        }
        public static Grid Get { 
                                  get 
                                  { 
                                    if(g == null)
                                    { 
                                       g = new CurrentGrid(); 
                                    }
                                    return g; 
                                  } 
                               }
    }
