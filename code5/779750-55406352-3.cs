    	System.Drawing.Image img = System.Drawing.Image.FromFile(@"E:\Mis Documentos\Mis imágenes\ergo-proxy-fullon-fight.jpg");
    	System.Drawing.Image circle = Util.CropToCircle(img, new System.Drawing.Size(64,64), System.Drawing.Color.White);
    	if (circle != null)
    	{
    		this.picUser.Image = circle;
    	}
