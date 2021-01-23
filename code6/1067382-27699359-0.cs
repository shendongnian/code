First, Note:
        /// <summary>
        /// A musical note
        /// </summary>
        public class Note
        {
            public enum Notes
            {
                Ab = 10,
                A = 0,
                Bb = 11,
                B = 1,
                C = 2,
                Db = 13,
                D = 3,
                Eb = 14,
                E = 4,
                F = 5,
                Gb = 16,
                G = 6
            }
            /// <summary>
            /// This holds the notes with accidentals
            /// </summary>
            public Notes noteLetter { get; private set; }
            /// <summary>
            /// this holds the note without any accidentals
            /// </summary>
            public Notes naturalLetter { get; private set; }
            /// <summary>
            /// Holds the value of the note if showsharp is true
            /// </summary>
            public Notes translatedLetter { get; private set; }
            /// <summary>
            /// Denotes whether or not the note will represented
            /// as its sharp counterpart, its prerequisite being
            /// that it was flat in the first place
            /// </summary>
            public bool showSharp { get; private set; }
    
            /// <summary>
            /// Creates a Note
            /// </summary>
            /// <param name="note">The basic note</param>
            /// <param name="sharp">Will be shown as it's sharp counterpart?</param>
            public Note(Notes note, bool sharp)
            {
                noteLetter = note;
                switch(noteLetter)
                {
                    case Notes.Ab:
                        naturalLetter = Notes.A;
                        translatedLetter = Notes.G;
                        break;
                    case Notes.Bb:
                        naturalLetter = Notes.B;
                        translatedLetter = Notes.A;
                        break;
                    case Notes.Db:
                        naturalLetter = Notes.D;
                        translatedLetter = Notes.C;
                        break;
                    case Notes.Eb:
                        naturalLetter = Notes.E;
                        translatedLetter = Notes.D;
                        break;
                    case Notes.Gb:
                        naturalLetter = Notes.G;
                        translatedLetter = Notes.F;
                        break;
                    default:
                        naturalLetter = noteLetter;
                        break;
                }
                showSharp = sharp;
    
                if (showSharp)
                {
                    switch (noteLetter)
                    {
                        case Notes.A:
                        case Notes.B:
                        case Notes.C:
                        case Notes.D:
                        case Notes.E:
                        case Notes.F:
                        case Notes.G:
                            showSharp = false;
                            break;
                    }
                }
    
            }
    
            /// <summary>
            /// Will make a random table of Note objects
            /// </summary>
            /// <param name="table">the array in which to place the Note objects</param>
            public static void MakeTable(out Note[,] table)
            {
                Note[,] temp = new Note[3, 4];
    
                Random rand = new Random();
    
                temp[0, 0] = new Note(Notes.Ab, (rand.Next(0, 2) == 0 ? true : false));
                temp[0, 1] = new Note(Notes.A, (rand.Next(0, 2) == 0 ? true : false));
                temp[0, 2] = new Note(Notes.Bb, (rand.Next(0, 2) == 0 ? true : false));
                temp[0, 3] = new Note(Notes.B, (rand.Next(0, 2) == 0 ? true : false));
                temp[1, 0] = new Note(Notes.C, (rand.Next(0, 2) == 0 ? true : false));
                temp[1, 1] = new Note(Notes.Db, (rand.Next(0, 2) == 0 ? true : false));
                temp[1, 2] = new Note(Notes.D, (rand.Next(0, 2) == 0 ? true : false));
                temp[1, 3] = new Note(Notes.Eb, (rand.Next(0, 2) == 0 ? true : false));
                temp[2, 0] = new Note(Notes.E, (rand.Next(0, 2) == 0 ? true : false));
                temp[2, 1] = new Note(Notes.F, (rand.Next(0, 2) == 0 ? true : false));
                temp[2, 2] = new Note(Notes.Gb, (rand.Next(0, 2) == 0 ? true : false));
                temp[2, 3] = new Note(Notes.G, (rand.Next(0, 2) == 0 ? true : false));
    
                table = new Note[3, 4];
    
                for (int i = 0; i < 12; i++)
                {
                    int row;
                    int col;
    
                    row = rand.Next(0, 3);
                    col = rand.Next(0, 4);
    
                    while (table[row, col] != null)
                    {
                        //Randomly choose if either the row or column will be incremented
                        bool useRow = (rand.Next(0, 2) == 0 ? true : false);
    
                        //then increment one of them
                        if (useRow)
                        {
                            row = (row + 1) % 3;
                        }
                        else
                        {
                            col = (col + 1) % 4;
                        }
                    }
    
                    //Place notes in the empty registers
                    if (table[row, col] == null)
                    {
                        table[row, col] = temp[(int)(i / 4), i % 4];
                    }
                }
            }
        }
And Game1:
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
    
        KeyboardState KeyBState, prevKeybState;
    
        Texture2D sprite;
    
        Rectangle noteSource;
        Rectangle accSource;
    
        const int ACCIDENTAL_START_X = 840;
    
        const int BORDER_OFFSET = 12;
    
        Vector2 notePosition;
    
        SpriteFont font;
    
        /// <summary>
        /// The array of notes, row/column format
        /// </summary>
        Note[,] box;
    
        const int ROW_SIZE = 3, COLUMN_SIZE = 4;
    
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
    
            box = new Note[ROW_SIZE, COLUMN_SIZE];
            noteSource = new Rectangle(0, 0, 120, 120);
            accSource = new Rectangle(ACCIDENTAL_START_X, 0, 50, 50);
    
            notePosition = Vector2.Zero;
        }
    
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Note.MakeTable(out box);
    
            base.Initialize();
        }
    
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            sprite = Content.Load<Texture2D>("Note Pieces2");
            font = Content.Load<SpriteFont>("font");
            // TODO: use this.Content to load your game content here
        }
    
        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
    
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            KeyBState = Keyboard.GetState();
    
            if (KeyBState.IsKeyDown(Keys.Escape))
                this.Exit();
    
            if (KeyBState.IsKeyDown(Keys.Space) && prevKeybState.IsKeyUp(Keys.Space))
                Note.MakeTable(out box);
    
            // TODO: Add your update logic here
            prevKeybState = KeyBState;
            base.Update(gameTime);
        }
    
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
    
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            for (int r = 0; r < ROW_SIZE; r++)
            {
                for (int c = 0; c < COLUMN_SIZE; c++)
                {
                    Note temp = box[r, c];
                    notePosition.Y = r * noteSource.Width + ((r + 1) * BORDER_OFFSET);
                    notePosition.X = c * noteSource.Height + ((c + 1) * BORDER_OFFSET);
                    noteSource.X = (temp.showSharp ? (int)temp.translatedLetter : (int)temp.naturalLetter) * noteSource.Width;
    
                    spriteBatch.Draw(sprite, notePosition, noteSource, Color.White);
    
                    notePosition.X += noteSource.Width / 2;
                    notePosition.Y += 7;
    
                    spriteBatch.DrawString(font,
                        temp.noteLetter.ToString() + " " +
                        (temp.showSharp ? "#" : ""), notePosition, Color.Black);
    
                    notePosition.X -= noteSource.Width / 2;
                    notePosition.Y -= 7;
    
                    switch (temp.noteLetter)
                    {
                        case Note.Notes.Ab:
                        case Note.Notes.Bb:
                        case Note.Notes.Db:
                        case Note.Notes.Eb:
                        case Note.Notes.Gb:
                            notePosition.X += 63;
                            notePosition.Y += 63;
    
                            int accOffset = 0;
                            if (temp.showSharp)
                            {
                                accSource.X = (int)temp.translatedLetter * noteSource.Width;
                            }
                            else
                            {
                                accSource.X = (int)temp.naturalLetter * noteSource.Width;
                                accOffset = accSource.Width;
                            }
    
                            accSource.X += accOffset;
                            accSource.Y = noteSource.Height;
                            spriteBatch.Draw(sprite, notePosition, accSource, Color.White);
                            break;
                    }
    
                }
            }
            spriteBatch.End();
            base.Draw(gameTime);
          }
        }
