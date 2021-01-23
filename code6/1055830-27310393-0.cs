    public static class Extensions
    {
        public static void displayThatView(this Form fx) 
        {  
            if (fx == null || fx.IsDisposed) {  
                Form fy = new fx();  
                fx.Show;  
            }  
            else {  
                if (!fx.Visible) {  
                    fx.Show;  
                    fx.Activate();  
                }  
                else {  
                    fx.Activate();  
                }  
            }  
        }  
    }
