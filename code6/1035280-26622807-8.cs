    public class Image : Form
    {
        public string FileName { get; set; }
        public Image()
        {
        }
        
        void timer1_Elapsed(object sender, ElapsedEventArgs e)
        {
            ....
            File.Delete(Path.Combine(Application.StartupPath, this.Filename));
            this.Close();
        }        
    }
