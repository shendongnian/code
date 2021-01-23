    var root = new RootElement ("Tasks"){
        new Section ("Process Type"){
            (MonoTouch.Dialog.Element)new RootElement ("Process", new RadioGroup ("processtype", 0)){
                new Section (){
                    guarantor,dependent, volunteer // all these are Elements    
                }
            }
        }       
    }; 
