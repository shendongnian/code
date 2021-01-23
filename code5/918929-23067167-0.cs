        private void LoadTrainingData(string folderLocation)
        {
            var filePath = folderLocation + "\\TrainedLabels.xml";
            if (File.Exists(filePath))
            {
                var doc = XDocument.Load(folderLocation + "\\TrainedLabels.xml");
                var items = doc.Root.Elements("FACE");
                foreach (var item in items)
                {
                    var names = item.Elements("NAME");
                    var ages = item.Elements("Age");
                    var faces = item.Elements("FACE");
                }
            }
        }
