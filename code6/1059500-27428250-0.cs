        private void button1_Click(object sender, EventArgs e)
        {
            // ...
            jouerSon(new String[] { "_" + nbre1, operateur, "_" + nbre2, "equal" });
            // ...
        }
        public void jouerSon(String[] sons)
        {
            Task t = new Task(() =>
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                foreach (String son in sons)
                {
                    player.Stream = Properties.Resources.ResourceManager.GetStream(son);
                    player.PlaySync();
                }    
            });
            t.Start();
        }
