    public class KewlButton : Button {
      public delegate void SetBackColor(Color color);
      static SetBackColor setBackColor;
      public KewlButton(){
        setBackColor += ChangeBackColor;
        Disposed += (s,e) => {
           setBackColor -= ChangeBackColor;
        };
      }
      private void ChangeBackColor(Color color){ 
         BackColor = color;
      }
      public class Crossdress {
        public static Color BackColor { 
            set {
                if(setBackColor!=null) setBackColor(value);
            }
        }
      }
    }
    //Usage
    KewlButton.Crossdress.BackColor = Color.Red;
