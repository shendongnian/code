    RenderLoop.Run(form, () =>
    {
       context.ClearRenderTargetView(renderView, Color.Black);  
       .... 
       context.InputAssembler.SetVertexBuffers(0, vb);                              
       context.Draw(sectionsToDraw,0);
       context.InputAssembler.SetVertexBuffers(0, vb2);
       context.Draw(sectionsToDraw, 0);
       ....
    }
