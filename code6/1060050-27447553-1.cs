    public void Dispose()
            {
                    this.GLControl.Release(); // Releases OpenGL resources on the GPU
                   
                    this.GLControlHost.Dispose(); // Needed otherwise the child control is retained
                    this.GLImage.Source    = null; // Needed to avoid memory leak
                    this.GLImage           = null; // 
            }
