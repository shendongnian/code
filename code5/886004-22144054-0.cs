           string path = NameYourFile.Text + "_" + DateTime.Now.ToString("MM_dd_yyyy") + ".csv";
           if (!System.IO.File.Exists(path))
           {
               // Create file if no Exists
               using (StreamWriter sw = File.CreateText(path))
               {
                   sw.WriteLine(string.Format("{0},{1},{2}", "\"Time\"", "\"Big Motor Actual Velocity\"", "\"Small Motor Actual Velocity\""));
               }
           }
           this.timer2.Start();
       }
       private void CreateCSVFile_Click(object sender, EventArgs e)
       {
           this.timer2.Stop();
           MessageBox.Show("File is Created");
       }
       private void timer2_Tick(object sender, EventArgs e)
       {
           string dt = DateTime.Now.ToString("hh.mm.ss.ffffff");
           string var1 = (dt);
           string var2 = adsClient.ReadAny(hActVel, typeof(double)).ToString(); ;
           string var3 = adsClient.ReadAny(hSActVel, typeof(double)).ToString(); ;
           StreamWriter sw = File.AppendText(NameYourFile.Text + "_" + DateTime.Today.ToString("MM_dd_yyyy") + ".csv");
           {
               if (BigMotorActualVelocity.Checked && SmallMotorActualVelocity.Checked)
               {
                   sw.WriteLine(string.Format("{0},{1},{2}",var1, var2, var3));
               }
               else if (BigMotorActualVelocity.Checked)
               {
                   sw.WriteLine(string.Format("{0},{1}",var1 , var2));
               }
               else if (SmallMotorActualVelocity.Checked)
               {
                   sw.WriteLine(string.Format("{0},{1},{2}",var1," ",var3));
               }
               else
               {
                   sw.WriteLine(string.Format("{0}",var1));
               }
               sw.Dispose();
           }
