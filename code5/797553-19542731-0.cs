    public class had
    {
        public void moveDown()
        {
           snakeRec[0].Y += 10; 
        }     
    }
    public class Form1 : Form
    {
        private had _model;
        public void moveDown()
        {
           _model.MoveDown();
           this.drawSnake();
        }     
        public void drawSnake()
        {
            for (int i = this._model.snakeRec.Length - 1; i > 0; i--)
            {
                ....
                label1.Text = "------"; 
                ....
            }
       }
    }
