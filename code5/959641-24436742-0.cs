                 named = DateTime.Now.ToString("dd-MM-yy HH:mm:ss:ms");
                TrainedFace.Save(Application.StartupPath + "/Temp/face1.bmp");
                string dated = DateTime.Now.ToString("HH:mm:ss:ff dd-MM-yy");
                label4.Text = dated;
                //Show face added in gray scale
                imageBox1.Image = TrainedFace;
                trainingImages.Add(TrainedFace);
                labels.Add(label4.Text);
                byte[] imagepic = null;
                FileStream fsstream = new FileStream(Application.StartupPath + "/Temp/face1.bmp", FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fsstream);
                imagepic = br.ReadBytes((int)fsstream.Length);
                string myConnection = "datasource=sql4.freemysqlhosting.net;port=3306;user=sql434250;password=lE3!lQ5*";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand SelectCommand = new MySqlCommand("INSERT INTO `sql434250`.`facialid` (`id`, `timeanddate`, `photo1`) VALUES (NULL, @dated, @IMG);", myConn);
                MySqlDataReader myReader;
                
                    myConn.Open();
                    SelectCommand.Parameters.Add(new MySqlParameter("@IMG", imagepic));
                    SelectCommand.Parameters.Add(new MySqlParameter("@dated", dated));
                    myReader = SelectCommand.ExecuteReader();
                    
                    while (myReader.Read())
                    {                    
                    }
