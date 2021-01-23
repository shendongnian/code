    ContainerVisual cv;
    private void sizeChanged_handler(object sender, SizeChangedEventArgs e){
       if(cv == null) {            
            cv = VisualTreeHelper.GetChild(vb, 0) as ContainerVisual;
       }
       //cv.Transform is in fact a ScaleTransform
       toolTipContent.LayoutTransform = cv.Transform;
    }
