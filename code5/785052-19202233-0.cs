    private void button1_Click(object sender, EventArgs e)
        {
            new System.Threading.Thread(testMethod).Start(); //starting a new thread
        }
        public void testMethod() //method will play sound and start timer after that
        {
            System.Media.SoundPlayer sp = new System.Media.SoundPlayer(filepath);
            sp.Play();
            timer1.Start();
        }
