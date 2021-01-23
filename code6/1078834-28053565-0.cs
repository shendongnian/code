    public partial class Form1 : Form
    {
        private Doc m_Doc;
      
        ....
        private void Form1_Load(object sender, EventArgs e)
        {
            m_Doc = new Doc("C:\\lorem_ipsum.doc");
            pictureBox1.Image = m_Doc.images[0];
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = m_Doc.images[numericUpDown1.Value];
        }
    }
