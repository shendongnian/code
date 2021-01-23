    public partial class UsDesiredName : UserControl3
    {
        //Some code for your class
        private void ValidateData()
        {
            var data = gc_view.DataSource as List<MyModel>;
            foreach (var item in data)
            {                
                item.ClearErrors();
                if (condition for columnA)
                {
                    item.NoteError = "Required fields.";
                    item.SetColumnError("NameOfColumnA", "Required field.");                                       
                }  
                
                if (condition for columnB)
                {
                    item.NoteError = "Required fields.";                    
                    item.SetColumnError("NameOfColumnB", "Required field.");                    
                }    
            }
        }
        
        private void gc_view_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            ValidateData()
        }
    }
