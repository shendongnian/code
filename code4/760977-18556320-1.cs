        public void LoadData()
        {
            // Load data
            //LoadCodeData();
            LoadXamlData();
            IsDataLoaded = true;
        }
        private void LoadXamlData()
        {
            string path = "SoundBoard;component/assets/runtimecontent/SampleData.xaml";
            Uri uri = new Uri(path, UriKind.Relative);
            using (System.IO.StreamReader reader = new System.IO.StreamReader((System.Windows.Application.GetResourceStream(uri)).Stream))
            {
                SoundModel model = System.Windows.Markup.XamlReader.Load(reader.ReadToEnd()) as SoundModel;
                this.Animals = model.Animals;
                this.Cartoons = model.Cartoons;
                this.Taunts = model.Taunts;
                this.Warnings = model.Warnings;
                this.CustomSounds = model.CustomSounds;
            }
        }
