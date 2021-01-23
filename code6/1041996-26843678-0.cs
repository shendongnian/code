    using System;
    using System.Drawing;
    using MonoTouch.Foundation;
    using MonoTouch.UIKit;
    using MonoTouch.CoreAnimation;
    using MonoTouch.CoreGraphics;
    using MonoTouch.ObjCRuntime;
    
    namespace SampleApp
    {
    	public class GradientView : UIView
    	{
    //		public new CAGradientLayer Layer { get; private set; }
    		private CAGradientLayer gradientLayer {
    			get { return (CAGradientLayer)this.Layer; }
    		}
    
    		public GradientView ()
    		{
            }
    
    		[Export ("layerClass")]
    		public static Class LayerClass ()
    		{
    			return new Class (typeof(CAGradientLayer));
    		}
    
    		public void setColors(CGColor[] colors){
    			this.gradientLayer.Colors = colors;
    		}
    
    //		public override void Draw (RectangleF rect)
    //		{
    //			// Do nothing, the Layer will do all the drawing
    //		}
    	}
    }
