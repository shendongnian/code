    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework.Media;
    using System.Collections.Generic;
    namespace WindowsGame1
    {
        public class GameStateManager
        {
            private static List<GameState> GameStates = new List<GameState>();
            private static GameState CurrentGameState = null;
            public static void AddState(GameState gameState)
            {
                GameStates.Add(gameState);
            }
            public static GameState GetState(string name)
            {
                return GameStates.Find(gameState => gameState.Name == name);
            }
            public static void SwitchStates(GameState gameState)
            {
                if (CurrentGameState != null)
                {
                    if (MediaPlayer.State == MediaState.Playing)
                        MediaPlayer.Stop();
                }
                CurrentGameState = gameState;
                if (CurrentGameState != null)
                    MediaPlayer.Play(CurrentGameState.Song);
            }
            public static void SwitchStates(string gameState)
            {
                SwitchStates(GetState(gameState));
            }
            public static void Dispose()
            {
                foreach (var gameState in GameStates)
                {
                    gameState.Song.Dispose();
                }
                GameStates.Clear();
            }
        }
        public class GameState
        {
            public Song Song;
            public string Name;
            public GameState(string name, Song song)
            {
                Name = name;
                Song = song;
            }
        }
        public class Game1 : Game
        {
            private GraphicsDeviceManager _graphicsDeviceManager;
            private KeyboardState _keyboardState;
            public Game1()
            {
                _graphicsDeviceManager = new GraphicsDeviceManager(this);
                Content.RootDirectory = "Content";
            }
            protected override void LoadContent()
            {
                GameStateManager.AddState(new GameState("InGame", Content.Load<Song>("song1")));
                GameStateManager.AddState(new GameState("Menu", Content.Load<Song>("song2")));
            }
            protected override void UnloadContent()
            {
                GameStateManager.Dispose();
            }
            protected override void Update(GameTime gameTime)
            {
                var keyboardState = Keyboard.GetState();
                if (keyboardState.IsKeyDown(Keys.A) && _keyboardState.IsKeyUp(Keys.A))
                {
                    GameStateManager.SwitchStates("Menu");
                }
                else if (keyboardState.IsKeyDown(Keys.B) && _keyboardState.IsKeyUp(Keys.B))
                {
                    GameStateManager.SwitchStates("InGame");
                }
                else if (keyboardState.IsKeyDown(Keys.C) && _keyboardState.IsKeyUp(Keys.C))
                {
                    GameStateManager.SwitchStates("Undefined");
                }
                _keyboardState = keyboardState;
                
                base.Update(gameTime);
            }
            protected override void Draw(GameTime gameTime)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
                base.Draw(gameTime);
            }
        }
    }
