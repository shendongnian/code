    using System;
    using System.Linq;
    using CoreAnimation;
    using CoreGraphics;
    using Foundation;
    using YourProject.Effects;
    using YourProject.iOS.Effects;
    using Serilog;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.iOS;
    
    
    [assembly:ResolutionGroupName ("YourCompany")]
    [assembly: ExportEffect(typeof(IosGradientEffect), "GradientEffect")]
    namespace YourProject.iOS.Effects
    {
        public class IosGradientEffect : PlatformEffect
        {
            protected override void OnAttached()
            {
                try
                {
                    var nativeView = Control ?? Container;
                    var effect = (GradientEffect) Element.Effects.FirstOrDefault(e => e is GradientEffect);
                    if (effect == null) return;
    
                    var colors = effect.ColorList.Select(i => i.ToCGColor()).ToArray();
    
                    var gradientLayer = new CAGradientLayer
                    {
                        Locations = effect.LocationList?.Select(i => new NSNumber(i)).ToArray()
                    };
    
                    switch (effect.Mode)
                    {
                        default:
                            gradientLayer.StartPoint = new CGPoint(0, 0.5);
                            gradientLayer.EndPoint = new CGPoint(1, 0.5);
                            break;
                        case GradientMode.ToLeft:
                            gradientLayer.StartPoint = new CGPoint(1, 0.5);
                            gradientLayer.EndPoint = new CGPoint(0, 0.5);
                            break;
                        case GradientMode.ToTop:
                            gradientLayer.StartPoint = new CGPoint(0.5, 1);
                            gradientLayer.EndPoint = new CGPoint(0.5, 0);
                            break;
                        case GradientMode.ToBottom:
                            gradientLayer.StartPoint = new CGPoint(0.5, 0);
                            gradientLayer.EndPoint = new CGPoint(0.5, 1);
                            break;
                        case GradientMode.ToTopLeft:
                            gradientLayer.StartPoint = new CGPoint(1, 1);
                            gradientLayer.EndPoint = new CGPoint(0, 0);
                            break;
                        case GradientMode.ToTopRight:
                            gradientLayer.StartPoint = new CGPoint(0, 1);
                            gradientLayer.EndPoint = new CGPoint(1, 0);
                            break;
                        case GradientMode.ToBottomLeft:
                            gradientLayer.StartPoint = new CGPoint(1, 0);
                            gradientLayer.EndPoint = new CGPoint(0, 1);
                            break;
                        case GradientMode.ToBottomRight:
                            gradientLayer.StartPoint = new CGPoint(0, 0);
                            gradientLayer.EndPoint = new CGPoint(1, 1);
                            break;
                    }
    
                    gradientLayer.Frame = nativeView.Bounds;
                    gradientLayer.Colors = colors;
    
                    nativeView.Layer.InsertSublayer(gradientLayer, 0);
                }
                catch (Exception ex)
                {
                    Log.Fatal(ex.Message);
                }
            }
    
            protected override void OnDetached()
            {
                Log.Debug("Gradient Effect Detached");
            }
        }
    }
    
