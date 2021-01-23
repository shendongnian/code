       public string [] imagepath; 
       OpenFileDialog op = new OpenFileDialog();
            op.Multiselect = true;
            if (op.ShowDialog() != DialogResult.Cancel)
            {
                imagepath = new string[op.SafeFileNames.Length];
                imagepath = op.
            }
