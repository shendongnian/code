    public class ChessPanel : Panel {
    
         private const Color HighlightColor = Color.Red;
    
    
         public int iColumn { get; set; }
         public int iRow { get; set; }
         public Color PrimaryColor { get; set; }
         
         public ChessPanel() : base()
         {
         	this.MouseEnter += (s,e) =>
                    {
                        this.PrimaryColor = this.BackColor;
                        this.BackColor = HighlightColor;
                    };
                    
             this.MouseLeave += (s,e) => 
                    {
                    	this.BackColor = this.PrimaryColor;
                    };
         }     
    
    }    
        
