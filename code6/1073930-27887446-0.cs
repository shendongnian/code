    try
            {
                string id = textBox4.Text.Trim(); 
                Directory.CreateDirectory("C:\\Users\\prashan\\Desktop\\"+id);
                string source = null;
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    source = ofd.FileName;
                    MessageBox.Show(source);
                }
                string File_name = Path.GetFileName(source);
                string destination = "C:\\Users\\prashan\\Desktop\\" + id +"\\"+ File_name;
                System.IO.File.Copy(source, destination);
                MessageBox.Show("Done....");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
