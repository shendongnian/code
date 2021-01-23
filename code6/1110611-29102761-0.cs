    private void gv_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
    {
      //Suppress displaying the error message box
      e.ExceptionMode = ExceptionMode.NoAction;
    }
