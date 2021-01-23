        if (response == DialogResult.OK)
        {
            string[] files = Directory.GetFiles(Lectura.SelectedPath);
            ListBox archivosListBox = new ListBox();
            archivosListBox.Items.AddRange(files);
            int tamanoLista = archivosListBox.Items.Count;
            List <string[]> Miarchivo = new List<string[]>();
            foreach (string archivos in archivosListBox.Items)
            {
              Miarchivo.Add(System.IO.File.ReadAllLines(archivos));
            }
            // Output into textBox1
            StringBuilder sb = new StringBuilder();
            foreach(String[] leerArchivo in Miarchivo) 
              foreach(String item in leerArchivo) {
                if (sb.Length > 0) 
                  sb.AppendLine(); // <- Or other deriver, e.g. sb.Append(';');
                sb.Append(item);
              }
            // Pay attention: textBox1 has been updated once only
            textBox1.Text = sb.ToString();
        }
