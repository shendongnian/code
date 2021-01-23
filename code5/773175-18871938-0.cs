    foreach (var pb in groupBox1.Controls.OfType<PictureBox>().OrderBy(p=>p.Name))
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
