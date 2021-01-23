        private System.Collections.Generic.List<string> championsList;
        private System.Collections.Generic.List<string> rolesList;
        
        public void loadList(string file){
            if (championsList == null) championsList = new System.Collections.Generic.List<string>();
            if (rolesList == null) rolesList = new System.Collections.Generic.List<string>();
            try {
                using (StreamReader r = new StreamReader(file))
                {
                   ...
                }
            } catch (Exception) {
            }
        }
        void Btn_DownloadClick(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            if (championsList == null) championsList = new System.Collections.Generic.List<string>();
            if (rolesList == null) rolesList = new System.Collections.Generic.List<string>();
            progressBar.Maximum = championsList.Count * rolesList.Count;
            int count = 0;
            progressBar.Value = 0;
            string fileName = "";
            string url = "";
            string path = "";
            foreach (string c in championsList)
            {
                foreach (string r in rolesList)
                {
                    ...
                }
            }
            progressBar.Value = progressBar.Maximum;
            MessageBox.Show("Download completed!\n" + count.ToString() + " item lists successfully downloaded.");
        }
