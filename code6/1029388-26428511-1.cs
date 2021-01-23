    public class PlayableCharacter:Rectangle {
    
      //position in a cartesian space
      private  int _cartesianPositionX;
      private  int _cartesianPositionY;
    
      //attributes of a rectangle
      private  int _characterWidth;
      private  int _characterHeight;
    
        public PlayableCharacter(int x, int y, int width, int height)
        {
           this._cartesianPositionX=x;
           this._cartesianPositionY=y;
           this._chacterWidth=width;
           this._characterHeight=height;
        }
        
        public bool DetectCollision(PlayableCharacter pc, PlayableCharacter obstacle)
        {
         // this a test in your method
            int x=10;
            if (pc.IntersectsWith(obstacle)){
                Console.Writeline("The rectangles touched");
                ChangeMovingDirection(x);
            }
      
        }
    
       private void ChangeMovingDirection(int x)
       {
         x*=-1;
         cartesianPositionX+=x;
       }
    }
