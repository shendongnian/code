            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                var bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(filename, UriKind.Absolute); 
                bi.EndInit();
                MyImage.Source = bi;
            }
