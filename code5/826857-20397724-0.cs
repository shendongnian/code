            /// <summary>
        /// Saves the current Settings collection to a file
        /// </summary>
        internal void BackupSettings()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON files (*.json)|*.json";
            saveFileDialog.InitialDirectory = @"C:\Beam.NET\Settings backups";
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    List<BsonDocument> settingsList = _beamDatabaseClient.GetAllSettings();
                    using (StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName, false))
                    {
                        foreach (var bsonDocument in settingsList)
                        {
                            var json = bsonDocument.ToJson();
                            streamWriter.WriteLine(json);
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Failed to Backup Settings",
		                            "Critical Warning",
		                            MessageBoxButtons.OK,
		                            MessageBoxIcon.Warning,
		                            MessageBoxDefaultButton.Button1,
		                            MessageBoxOptions.RightAlign,
		                            true);
                }
            }
        }
        /// <summary>
        /// Restores the Settings collection from a file
        /// </summary>
        internal void RestoreSettings()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files (*.json)|*.json";
            openFileDialog.InitialDirectory = @"C:\Beam.NET\Settings backups";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _beamDatabaseClient.DeleteSettings();
                    using (StreamReader streamReader = new StreamReader(openFileDialog.FileName))
                    {
                        string json;
                        while((json = streamReader.ReadLine()) != null)
                        {
                            var bsonDocument = BsonDocument.Parse(json);
                            _beamDatabaseClient.WriteBSONRecord(Collections.Settings, bsonDocument);
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Failed to Restore Settings",
                                    "Critical Warning",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning,
                                    MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.RightAlign,
                                    true);
                }
            }  
        }
    }
