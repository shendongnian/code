    Method1() {
     try { 
         //Code for Method1 
         }catch(Exception ex) { throw new CustomException(""); }
    }
    
    Method2() {
     try { 
         //Code for Method2 
         }catch(Exception ex) { throw new CustomException(""); }
    }
    
    Method3() {
     try { 
         //Code for Method3 
         }catch(Exception ex) { throw new CustomException(""); }
    }
    
    
    try {
        Method1();
        Method2();
        Method3();
    }catch(CustomException custom) {
     // You would know specific reasons for crashing.. and can return meaningful message to UI.
     } catch(Exception ex) { 
     //Anything that was un-handled
    }
    
    
    class CustomException : Exception {
     //Implementation here..
    }
