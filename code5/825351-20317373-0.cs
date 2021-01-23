        openWork.CheckFileExists = true;
        if (openWork.ShowDialog() == DialogResult.OK)
        {
            // Check if you really have a file name 
            if(openWork.FileName.Trim() != string.Empty)
            {
                using (StreamReader r = new StreamReader(openWork.FileName))
                {
                    string json = r.ReadToEnd();
                    Person items = JsonConvert.DeserializeObject<Person>(json);
                }
            }
        }
