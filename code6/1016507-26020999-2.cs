     public void ApplySettings(int Height, int Width)
     {
         if (Width > 0 && Height > 0) { this.Size = new Size(Width, Height); }
     }
    
     myForm.ApplySettings(100,200);
