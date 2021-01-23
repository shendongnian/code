    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Collections.Generic;
    
    
    /// <summary>
    /// Scrolling Background - Bewegender Hintergrund
    /// </summary>
    
    
    public class ScrollingBackground : Form
    {
    
        /*      this = fremde Attribute und Methoden, 
         * ohne this = eigene Attribute und Methoden
         */
    
    
        private PictureBox picBoxImage;
        private PictureBox[] listPicBoxAufeinanderfolgendeImages;
        private Timer timerBewegungImage;
        
    
        private const int constIntAnzahlImages = 2,
                          constIntInterval = 1,
                          constIntPositionY = 0;
    
        private int intPositionX = 0,
                    intFeinheitDerBewegungen,
                    intBreite,
                    intHoehe;
    
        private string stringTitel,
                       stringBildpfad;
        
        
        
    
        // Konstruktor der Klasse Hintergrund
        
        /// <summary>
        /// Initialisiert eine neue Instanz der Klasse Hintergrund unter Verwendung der angegebenen Ganzzahlen und Zeichenketten.
        /// Es wird ein Windows-Fenster erstellt, welches die Möglichkeit hat, ein eingefügtes Bild als bewegenden Hintergrund darzustellen.
        /// </summary>
        /// <param name="width">Gibt die Breite des Fensters an und passt den darin befindlichen Hintergrund bzgl. der Breite automatisch an.</param>
        /// <param name="height">Gibt die Höhe des Fensters an und passt den darin befindlichen Hintergrund bzgl. der Höhe automatisch an.</param>
        /// <param name="speed">Geschwindigkeit der Bilder</param>
        /// <param name="title">Titel des Fensters</param>
        /// <param name="path">Pfad des Bildes, welches als Hintergrund dient</param>
        
        public ScrollingBackground(int width, int height, int speed, string title, string path) 
        {
            
            // Klassennutzer können Werte setzen
            intBreite = width;
            intHoehe = height;
            intFeinheitDerBewegungen = speed;
            stringTitel = title;
            stringBildpfad = path;
    
    
            // Windows-Fenster wird erschaffen
            this.Text = title;
            this.Size = new Size(this.intBreite, this.intHoehe);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
    
    
            // Die Bewegung des Bildes wird durch den Timer ermöglicht.
            timerBewegungImage = new Timer();
            timerBewegungImage.Tick += new EventHandler(bewegungImage_XRichtung_Tick);
            timerBewegungImage.Interval = constIntInterval;
            timerBewegungImage.Start();
    
    
            listPicBoxAufeinanderfolgendeImages = new PictureBox[2];
    
    
            imageInWinFormLadenBeginn();
    
    
            this.ShowDialog();
            
        }
    
        // Bewegungsrichtung des Bildes
        private void bewegungImage_XRichtung_Tick(object sender, EventArgs e)
        {
    
            for (int i = 0; i < constIntAnzahlImages; i++)
            {
    
                picBoxImage = listPicBoxAufeinanderfolgendeImages[i];
    
    
                // Flackerreduzierung - Minimierung des Flackerns zwischen zwei Bildern
                this.DoubleBuffered = true;
    
    
                // Bilder werden in X-Richtung bewegt
                picBoxImage.Location = new Point(picBoxImage.Location.X - intFeinheitDerBewegungen, picBoxImage.Location.Y);
    
    
                // Zusammensetzung beider gleicher Bilder, welche den Effekt haben, die Bilder ewig fortlaufend erscheinen zu lassen
                if (listPicBoxAufeinanderfolgendeImages[1].Location.X <= 0)
                {
    
                    imageInWinFormLadenFortsetzung();
    
                }
    
            }
    
        }
    
        // zwei PictureBoxes mit jeweils zwei gleichen Bildern werden angelegt
        private void imageInWinFormLadenBeginn()
        {
    
            Bitmap bitmapImage = new Bitmap(stringBildpfad);
    
    
            for (int i = 0; i < constIntAnzahlImages; i++)
            {
    
                // Bild wird in Fenster geladen
                picBoxImage = new PictureBox();
                picBoxImage.Image = bitmapImage;
    
    
                // Bestimmung der Position und Größe des Bildes
                picBoxImage.SetBounds(intPositionX, constIntPositionY, intBreite, intHoehe);
                this.Controls.Add(picBoxImage);
    
    
                listPicBoxAufeinanderfolgendeImages[i] = picBoxImage;
    
    
                // zwei PictureBoxes mit jeweils zwei gleichen Bildern werden nebeneinander angefügt
                intPositionX += intBreite;
    
            }
    
        }
    
        // Wiederholte Nutzung der PictureBoxes
        private void imageInWinFormLadenFortsetzung()
        {
    
            // erste PictureBox mit Image wird wieder auf ihren Anfangswert "0" gesetzt - Gewährleistung der endlos laufenden Bilder
            picBoxImage = listPicBoxAufeinanderfolgendeImages[0];
            picBoxImage.SetBounds(intPositionX = 0, constIntPositionY, intBreite, intHoehe);
    
    
            // zweite PictureBox mit Image wird wieder auf ihren Anfangswert "intBreite" gesetzt - Gewährleistung der endlos laufenden Bilder
            picBoxImage = listPicBoxAufeinanderfolgendeImages[1];
            picBoxImage.SetBounds(intPositionX = intBreite, constIntPositionY, intBreite, intHoehe);
    
        }
    
    }
