    internal static void WriteToStream(IEnumerable<Basket.Basket> items, Func<StreamWriter> createStream){
       using (var streamwriter = createStream())
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
               WriteToStream(lst_Results.Items,() => new StreamWriter(FileSave.FileName, false));
                MessageBox.Show("Success");
            }
        }
    }
