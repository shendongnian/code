        private void d3dImage_IsFrontBufferAvailableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
             if (d3dImage.IsFrontBufferAvailable)
             {
                 initialize();
             }
             else
             {
                 // Cleanup:
                 CompositionTarget.Rendering -= CompositionTarget_Rendering;
                 DLL.Cleanup();
             }
         }
