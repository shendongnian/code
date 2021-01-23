      using System.Windows.Controls;
       public class CustomDataGrid : DataGrid
       {
      
        protected override void OnSelectedCellsChanged(SelectedCellsChangedEventArgs e)
        {
            //to make sure cell is selected
            var cells = e.AddedCells.FirstOrDefault();
            if (cells != null)
            {
                this.BeginEdit();
            }
            base.OnSelectedCellsChanged(e);
        }
       }
