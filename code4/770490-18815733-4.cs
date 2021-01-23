    class star
        {
            Texture2D starT;
            public Vector2 star_pos;
            Vector2 position_when_hit;
            Vector2 destinatin;
            float percent;
            bool star_moving_up;
    
            public star(Random rand,Texture2D star)
            {
                this.starT = star;
                star_moving_up = false;
                destinatin = new Vector2(800, 0);
                star_pos = new Vector2(rand.Next(500), rand.Next(500));
            }
    //Try to call this only once
            public void on_hit(){
                if (!star_moving_up)
                {
                    position_when_hit = star_pos;
                    star_moving_up = true;
                }
            }
    
            public void update(GameTime gameTime)
            {
                if (star_moving_up)
                {
                    star_pos = Vector2.Lerp(position_when_hit, destinatin, percent);
                    //a larger percent value will move the star faster.
                    percent += 0.001f;
                }
                else
                {
                    //Your Logic for moving it down
                }
            }
    
            public void draw(SpriteBatch sp)
            {
                sp.Draw(starT, star_pos, Color.White);
            }
    }
