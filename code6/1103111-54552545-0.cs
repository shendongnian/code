     private bool _IsEscape = false; // private field
             
    
        void Update(){
             if(Input.GetKeyUp(KeyCode.ESCAPE)){
                 if (_IsEscape)
                        {                        
                            Application.Quit();
                        }
                        else
                        {
                            _IsEscape = true;                        
                            if (!IsInvoking("DisableDoubleClick"))
                                Invoke("DisableDoubleClick", 0.3f);
    
    
                        }
                    }
             }
             
         }
         
         void DisableDoubleClick(){
             _IsEscape = false;
         }
