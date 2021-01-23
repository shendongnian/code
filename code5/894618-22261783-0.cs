    private void Form1_Load(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open .ODI file";
            ofd.Filter = "ODI Files (*.odi)|*odi";
            DialogResult result = ofd.ShowDialog();
            if (result == DialogResult.Cancel)
                //return;   jux remove this return and ur code will work fine
                // actually we dont use return in the body of if condition.. bad practice
        
            MessageBox.Show("bla");
            FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
            FileStream fs1 = new FileStream(Path.GetDirectoryName(ofd.FileName) + "\\VOL1.DAT", FileMode.Open, FileAccess.Read);
            //------------------------CODE IS NOT EXECUTED AFTER THIS
            MessageBox.Show("bla2");
            //getting the Main Folders
            byte[] fldrn = new byte[4]; 
            fs.Position = 0x74;
            fs.Read(fldrn, 0, 4);
            int fldrnum = BitConverter.ToInt32(fldrn, 0);
            MessageBox.Show(fldrnum.ToString(), "1");
    
            byte[] namaes = new byte[28];
            foldernames = new string[fldrnum];
            for (int i = 0; i < fldrnum; i++)
            {
                fs.Position = 0x88 + i*4;
                fs.Position = 0x74;
                fs.Read(fldrn, 0, 4);
                int fldrnam = BitConverter.ToInt32(fldrn, 0);
                int pos = (int)fs.Position;
    
                fs.Position = pos + fldrnam;
                fs.Read(namaes, 0, 28);
                foldernames[i] = Encoding.ASCII.GetString(namaes).Split('\0')[0];
                MessageBox.Show(foldernames[i], i.ToString());
                treeView1.Nodes[0].Nodes[0].Nodes.Add(foldernames[i]).ImageIndex = 1;
            }
        }
