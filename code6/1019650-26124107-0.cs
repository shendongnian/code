     private void _picBox_MouseDown(object sender, MouseEventArgs e)
     {
         if (e.Button == MouseButtons.Left)
         {
            var programFullPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var programDirectory = System.IO.Path.GetDirectoryName(programFullPath);
            var pic = (PictureBox) sender;
            pic.Image.Save(programDirectory+ @"\tmp.jpg");
            var files = new string[] {programDirectory+ @"\tmp.jpg"};
            var res = pic.DoDragDrop(new DataObject(DataFormats.FileDrop, files), DragDropEffects.Copy | DragDropEffects.Move);
            MessageBox.Show(res.ToString());
        }
     }
