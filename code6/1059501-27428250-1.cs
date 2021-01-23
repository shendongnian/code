        private void button1_Click(object sender, EventArgs e)
        {
            // ...
            jouerSon(nbre1, operateur, nbre2);
            // ...
        }
        public void jouerSon(string nbre1, string operateur, string nbre2)
        {
            Task t = new Task(() =>
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                player.Stream = Properties.Resources.ResourceManager.GetStream("_" + nbre1);
                player.PlaySync();
                player.Stream = Properties.Resources.ResourceManager.GetStream(operateur);
                player.PlaySync();
                player.Stream = Properties.Resources.ResourceManager.GetStream("_" + nbre2);
                player.PlaySync();
                player.Stream = Properties.Resources.ResourceManager.GetStream("equal");
                player.PlaySync();
            });
            t.Start();
        }
