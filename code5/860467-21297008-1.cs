    public class MyTextBoxThingy 
    {
        private TextBox[,] textboxes;
     
        public MyTextboxThingy() 
        { 
           Initialize();
        }
    
        private void initialize() {
           textboxes = new TextBox[,] { { box00, box01 }, { box10, box11 } };
        }
        
        private void MoveUp() { ... }
    }
