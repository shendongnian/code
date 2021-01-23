    using System;
    using System.Linq;
    using Android.Graphics;
    using Android.Graphics.Drawables;
    using Android.Graphics.Drawables.Shapes;
    using YourProject.Droid.Effects;
    using YourProject.Effects;
    using Serilog;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;
    
    [assembly:ResolutionGroupName ("YourCompany")]
    [assembly: ExportEffect(typeof(AndroidGradientEffect), "GradientEffect")]
    namespace YourProject.Droid.Effects
    {
        public class AndroidGradientEffect : PlatformEffect
        {
            protected override void OnAttached()
            {
                try
                {
                    var effect = (GradientEffect) Element.Effects.FirstOrDefault(e => e is GradientEffect);
    
                    var nativeView = Control ?? Container;
    
                    var colors = effect.ColorList.Select(i => i.ToAndroid().ToArgb()).ToArray();
    
                    var paint = new PaintDrawable();
                    paint.Shape = new RectShape();
                    paint.SetShaderFactory(new GradientShaderFactory(colors, effect.LocationList, Shader.TileMode.Mirror, effect.Mode));
    
                    nativeView.SetBackgroundDrawable(paint);
                }
                catch (Exception ex)
                {
                    Log.Fatal("Couldn't set property for view with effect ex:" + ex.Message);
                }
            }
    
            protected override void OnDetached()
            {
                Log.Debug("Android Gradient Effect detached");
            }
        }
    
        internal class GradientShaderFactory : ShapeDrawable.ShaderFactory
        {
            private readonly Shader.TileMode _tileMode;
            private readonly int[] _colors;
            private readonly float[] _locations;
            private readonly GradientMode _gradientMode;
    
    
            internal GradientShaderFactory(int[] colors, float[] locations, Shader.TileMode tileMode,
                GradientMode gradientMode)
            {
                _colors = colors;
                _locations = locations;
                _tileMode = tileMode;
                _gradientMode = gradientMode;
            }
    
            public override Shader Resize(int width, int height)
            {
                LinearGradient gradient;
                switch (_gradientMode)
                    {
                        default:
                            gradient = new LinearGradient(0, 0, width, 0, _colors, _locations,
                                _tileMode);
                            break;
                        case GradientMode.ToLeft:
                            gradient = new LinearGradient(width, 0, 0, 0, _colors, _locations,
                                _tileMode);
                            break;
                        case GradientMode.ToTop:
                            gradient = new LinearGradient(0, height, 0, 0, _colors, _locations,
                                _tileMode);
                            break;
                        case GradientMode.ToBottom:
                            gradient = new LinearGradient(0, 0, 0, height, _colors, _locations,
                                _tileMode);
                            break;
                        case GradientMode.ToTopLeft:
                            gradient = new LinearGradient(width, height, 0, 0,
                                _colors, _locations,
                                _tileMode);
                            break;
                        case GradientMode.ToTopRight:
                            gradient = new LinearGradient(0, height, width,0 ,
                                _colors, _locations,
                                _tileMode);
                            break;
                        case GradientMode.ToBottomLeft:
                            gradient = new LinearGradient(width, 0, 0, height,
                                _colors, _locations,
                                _tileMode);
                            break;
                        case GradientMode.ToBottomRight:
                            gradient = new LinearGradient(0, 0, width, height,
                                _colors,_locations,
                                _tileMode);
                            break;
                    }
    
                return gradient;
            }
        }
    }
