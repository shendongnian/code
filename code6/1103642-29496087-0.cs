    class Image {
        ............
        public static Image FromFile(String filename,
                                         bool useEmbeddedColorManagement) 
        {
            ............    
            //GDI+ will read this file multiple times. 
            ............
        }
    }
