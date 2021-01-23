    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework.Media;
    
    namespace WindowsGame1
    {
        public class Game1 : Game
        {
            private GameState _gameState;
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
                GameState gameState = _gameState;
                var keyboardState = Keyboard.GetState();
                if (keyboardState.IsKeyDown(Keys.A) && _keyboardState.IsKeyUp(Keys.A)) {
                    gameState = GameState.Menu;
                }
                else if (keyboardState.IsKeyDown(Keys.B) && _keyboardState.IsKeyUp(Keys.B)) {
                    gameState = GameState.InGame;
                }
                else if (keyboardState.IsKeyDown(Keys.C) && _keyboardState.IsKeyUp(Keys.C)) {
                    gameState = GameState.Undefined;
                }
                _keyboardState = keyboardState;
                if (gameState != _gameState) {
                    switch (gameState) {
                        case GameState.Undefined:
                            MediaPlayer.Stop();
                            break;
                        case GameState.Menu:
                            MediaPlayer.Stop();
                            MediaPlayer.Play(_song1);
                            break;
                        case GameState.InGame:
                            MediaPlayer.Stop();
                            MediaPlayer.Play(_song2);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    _gameState = gameState;
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
