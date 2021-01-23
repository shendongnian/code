    for(int x = 1; x < chunkCountX; x++)
    {
         for(int y=1; y < chunkCountY; y++)
         {
             string btnName = "Box" + x + y;
             if(this.Controls.ContainsKey(btnName)) 
                    this.Controls[btnName].BackgroundImage = presetImageVar;
         }
    }
