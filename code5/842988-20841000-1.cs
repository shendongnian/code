    using UnityEngine;
    using System.Collections;
    
    class ballmaterial 
    {
        private static ballmaterial instance;
        private ballmaterial() {}
        public static ballmaterial Instance {
           get {
               if (instance == null) {
                   instance = new ballmaterial();
               }
               return instance;
           }
        }
        
        public Material BallMaterial = null;
    }
