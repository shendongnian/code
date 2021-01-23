    LoadingAnimation loadingAnim = null;
    var viewer = ((DataGrid)e.Parameter).Template.FindName("DG_ScrollViewer")
                  as ScrollViewer;
    if(viewer != null){
       loadingAnim = viewer.Template.FindName("btnCustomWaitForExcel")
                     as LoadingAnimation;
       if(loadingAnim != null) loadingAnim.Visibility = Visibility.Visible;
    }
