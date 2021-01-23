            BinaryFormatter bin = new BinaryFormatter();
            int length = (int)bin.Deserialize(fs);
            MessageBox.Show(length.ToString());
            for (int i = 0; i < length; i++)
            {
                viewerData[i] = (ViewerData)bin.Deserialize(fs); //problem
            }
            for (int i = 0; i < viewerData.Length; i++)
            {
                PopulateFlowControl(viewerData[i]);
                viewerNameList.Add(viewerData[i].name);
            }
        }
