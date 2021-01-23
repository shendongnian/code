        private GUIStyle testStyle = new GUIStyle();
        public Texture2D Texture1;
    
        void OnGUI(){
    
        if( GUI.Button( new Rect (0, 0, 100, 100) , texture1 ,testStyle) )
            {
              //doSomething if clicked on   
            }
          }
