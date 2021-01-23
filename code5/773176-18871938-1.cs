    foreach (var pb in groupBox1.Controls.OfType<PictureBox>().OrderBy(p=>int.Parse(Regex.Replace(k,"\\D*",""))))
    {
         if(previewIndexer < Previewer.Count) {
                    try
                    {
                        ((PictureBox)pb).Image = ...
                        previewIndexer++;
                        ...
                    }
                    catch
                    {
                        ...
                    }
          }
    }
