    private void Button_Click(object sender, RoutedEventArgs e)
    {            
        Canvas complicatedCanvas = GenTechnicalDrawing();
        var vb = canvas1.Parent as Viewbox;
        if(vb != null){
           vb.Child = complicatedCanvas;
        }
    }
