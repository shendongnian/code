    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace WindowsFormsApplication7
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           Guy Joe = new Guy() {Money = 50}; 
          Guy Bob = new Guy() {Money = 75};
          Guy Al = new Guy() {Money = 45};
        Greyhound[] dog = new Greyhound[4];
        dog[0] = new Greyhound();
        }
      }
    public class Guy
    {
        public int Money;
    }
    class Greyhound
    {
        public int StartingPosition;
        public int RaceTrackLengh;
        public PictureBox MyPictureBox = null;
        public Random Randomizer;
        public int Location;
        public bool Run()
        {
            Location += Randomizer.Next(5);
            MyPictureBox.Left = StartingPosition + Location;
            if (Location >= RaceTrackLengh)
            {
                TakeStartingPosition();
                return true;
            }
            else
            {
                return false;
            }
        }
        private void TakeStartingPosition()
        {
            Location = 0;
            MyPictureBox.Left = StartingPosition;
        }
    }
    }
