    private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
    {
       if(e.Column.FieldName=="mycolumn")
       {
          e.DisplayText = (e.Value as MyClass).Product.Name;
       }
    }
