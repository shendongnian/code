    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework.Media;
    
    namespace WindowsGame1
    {
        public class Game1 : Game
        {
            private GraphicsDeviceManager _graphicsDeviceManager;
            private KeyboardState _keyboardState;
            private Song _song1;
            private Song _song2;
    
            public Game1() {
                _graphicsDeviceManager = new GraphicsDeviceManager(this);
                Content.RootDirectory = "Content";
            }
    
            protected override void LoadContent() {
                _song1 = Content.Load<Song>("song1");
                _song2 = Content.Load<Song>("song2");
            }
    
            protected override void UnloadContent() {
                if (_song1 != null) _song1.Dispose();
                if (_song2 != null) _song2.Dispose();
            }
    
            protected override void Update(GameTime gameTime) {
                GameState gameState = GameState.Undefined;
                var keyboardState = Keyboard.GetState();
                if (keyboardState.IsKeyDown(Keys.A) && _keyboardState.IsKeyUp(Keys.A)) {
                    gameState = GameState.Menu;
                }
                else if (keyboardState.IsKeyDown(Keys.B) && _keyboardState.IsKeyUp(Keys.B)) {
                    gameState = GameState.InGame;
                }
                _keyboardState = keyboardState;
    
                Song song;
                switch (gameState) {
                    case GameState.Undefined:
                        song = null;
                        break;
                    case GameState.Menu:
                        song = _song1;
                        break;
                    case GameState.InGame:
                        song = _song2;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                if (song != null) {
                    MediaPlayer.Stop();
                    MediaPlayer.Play(song);
                }
                base.Update(gameTime);
            }
    
            protected override void Draw(GameTime gameTime) {
                GraphicsDevice.Clear(Color.CornflowerBlue);
                base.Draw(gameTime);
            }
        }
    
        internal enum GameState
        {
            Undefined,
            Menu,
            InGame
        }
    }
