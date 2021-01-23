    UserControl1 newUC = new PST_UI_WPF_FieldOfView();
    Thumb tmbDragThumb = new Thumb();
    tmbDragThumb.DragDelta += new DragDeltaEventHandler(Thumb_DragDelta);
    ControlTemplate template = new ControlTemplate();
    var fec= new FrameworkElementFactory(typeof(UserControl1 ));
    template.VisualTree = fec;
    tmbDragThumb.Template = template;
    SweetCanvas.Children.Add(tmbDragThumb);
