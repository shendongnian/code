    void gridView2_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Column.Name == "UnboundColumn" && e.IsGetData)
            {
                // here you get the Id of the type
                var value = (int)view.GetListSourceRowCellValue(e.ListSourceRowIndex, TypeColumn);
                // here yoy get the Description, for example "Normal" or "Discount"
                var text = repositoryItemGridLookUpEdit1.Properties.GetDisplayText(value);
                
                // here you can whatever you want, for example set the text of an unbound column to something
                if(text == "Discount")
                    e.Value = "!!!!";
            }
        }
