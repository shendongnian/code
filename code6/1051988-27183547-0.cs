    private void btn_Original_Click(object sender, RoutedEventArgs e)//---------------------------------------> Event for getting Original size of canvas
        {
            Matrix m = CanvasPanel.RenderTransform.Value;
            m.SetIdentity();                 
            CanvasPanel.RenderTransform = new MatrixTransform(m);
        }
