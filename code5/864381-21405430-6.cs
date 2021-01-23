    public class Button
    {
        public Texture2D texture1;
        MouseState currentMouseState;
        MouseState lastMouseState;
        Texture2D texture2;
        Texture2D texture3;
        Vector2 position;
        Rectangle rectangle;
        public Vector2 size;
        public bool isMousOver;
        public bool isClicked;
        public bool isPressed;
        public Button(int texture1, int texture2, int texture3, int position_x, int position_y)
        {
            this.texture1 = Game_class.menue[texture1];
            this.texture2 = Game_class.menue[texture2];
            this.texture3 = Game_class.menue[texture3];
            this.position.X = position_x;
            this.position.Y = position_y;
            this.isMousOver = false;
            this.isClicked = false;
            this.isPressed = false;
            this.size = new Vector2(Game_class.menue[texture1].Width / 2, Game_class.menue[texture1].Height / 2);
            rectangle = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
        }
        public Button(int texture1, int texture2, int texture3, int position_x, int position_y, float x, float y)
        {
            this.texture1 = Game_class.menue[texture1];
            this.texture2 = Game_class.menue[texture2];
            this.texture3 = Game_class.menue[texture3];
            this.position.X = position_x;
            this.position.Y = position_y;
            this.isMousOver = false;
            this.isClicked = false;
            this.isPressed = false;
            this.size = new Vector2(Game_class.menue[texture1].Width / x, Game_class.menue[texture1].Height / y);
            rectangle = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
        }
        public void Update(MouseState mouse)
        {
            Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);
            lastMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();
            if (mouseRectangle.Intersects(rectangle))
            {
                this.isMousOver = true;
                if (currentMouseState.LeftButton == ButtonState.Pressed || lastMouseState.LeftButton == ButtonState.Pressed)
                {
                    isPressed = true;
                    if (lastMouseState.LeftButton == ButtonState.Pressed && currentMouseState.LeftButton == ButtonState.Released)
                    {
                        this.isClicked = true;
                    }
                    else
                    {
                        this.isClicked = false;
                    }
                }
                else
                {
                    isPressed = false;
                    isClicked = false;
                }
            }
            else
            {
                this.isMousOver = false;
                this.isClicked = false;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (isMousOver == true)
            {
                if (isPressed == true)
                {
                    spriteBatch.Draw(texture3, rectangle, Color.White);
                }
                else
                {
                    spriteBatch.Draw(texture2, rectangle, Color.White); 
                }
            }
            else
            {
                spriteBatch.Draw(texture1, rectangle, Color.White);
            }
            
        }
    }
 
