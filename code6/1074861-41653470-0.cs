    using( MagickImage ThisPicture = new MagickImage( JpegPicture ) )
    {
    	ThisPicture.Scale( XDimensions, YDimensions );
    	ThisPicture.ColorType = ColorType.Grayscale;
    	ThisPicture.Extent( XDimensions, YDimensions, Gravity.Center, MagickColors.Black );
    
    	using( PixelCollection ThisPixels = ThisPicture.GetPixels() )
    	{
    		byte Intensity = ThisPixels[ IX, IY ].GetChannel( 0 );
    	}
    }
