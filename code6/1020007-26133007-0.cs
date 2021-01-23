    <Image x:Name="myImage" Source="/Assets/ApplicationIcon.png" Stretch="None" ManipulationDelta="myImage_ManipulationDelta">
        <Image.RenderTransform>
            <CompositeTransform></CompositeTransform>
        </Image.RenderTransform>
    </Image>
----------
    private void myImage_ManipulationDelta(object sender, System.Windows.Input.ManipulationDeltaEventArgs e)
    {
        Image i = sender as Image;           
        CompositeTransform ct;
        if (i.RenderTransform is CompositeTransform)
        {
            ct = (CompositeTransform) i.RenderTransform;
            ct.TranslateX += e.DeltaManipulation.Translation.X;
            ct.TranslateY += e.DeltaManipulation.Translation.Y;
        }           
    }
