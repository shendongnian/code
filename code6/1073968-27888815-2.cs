    public class Form1
    {
        private void button1_Click(object sender, EventArgs e) //<- e is there
        {
            Draw(e.Graphics);
        }
    }
    public class Object : Form1
    {   
        public void Draw(Graphics mapGraphics)
        {
            SolidBrush brush = new SolidBrush(Color.Yellow);
            mapGraphics.FillEllipse(brush, new Rectangle(0, 0, 12, 12));
        }
    }
    
