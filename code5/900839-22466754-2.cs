    enum LayerState : byte
    {
        One,
        Two,
        Three,
        Four
    }
    void DrawLayer(LayerState state)
    {
        switch (state)
        {
            case One:
              forech (object obj in Layer1)
                SpriteBatch.Draw(obj);
            break;
            case Two:
              forech (object obj in Layer2)
                SpriteBatch.Draw(obj);
            break;
            case Three:
              forech (object obj in Layer3)
                SpriteBatch.Draw(obj);
            break;
            case Four:
              forech (object obj in Layer4)
                SpriteBatch.Draw(obj);
            break;
         }
    }
    
    public override void Draw()
    {
       SpriteBatch.Begin();
       DrawLayer(LayerState.Two) // play with states for result
       SpriteBatch.End();
       SpriteBatch.Begin();
       DrawLayer(LayerState.One) // play with states for result
       SpriteBatch.End();
       SpriteBatch.Begin();
       DrawLayer(LayerState.Three) // play with states for result
       SpriteBatch.End();
       SpriteBatch.Begin();
       DrawLayer(LayerState.Four) // play with states for result
       SpriteBatch.End();
    }
