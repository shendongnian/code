    internal static void WriteToStream(IEnumerable<Basket.Basket> items,string filename){
       using (var streamwriter = new StreamWriter(filename, false))
          foreach (var item in items){
               streamwriter.Write(item.ToString() + Environment.NewLine);
          }
        }
    }
    private void btn_Save_Click(object sender, EventArgs e)
        {
            var FileSave = new SaveFileDialog();
            FileSave.Filter = "Text (*.txt)|*.txt";
            if (FileSave.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
               WriteToStream(lst_Results.Items, FileSave.FileName);
                MessageBox.Show("Success");
            }
    
    }
