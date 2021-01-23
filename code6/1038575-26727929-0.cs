    public class Form1 : Form, IMyForm
    {
    
        public void ShowImage(Image image)
        {
            this.PictureBox1.Image = image;
        }
        private void menuitem_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2()
            frm2.Show(this); //Assign the owner as current form
        }
    
    }
