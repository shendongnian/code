GradientLayoutRenderer.cs
    using System;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media;
    using MyProject.Renderers;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.UWP;
    using Point = Windows.Foundation.Point;
    [assembly: ExportRenderer(typeof(GradientLayout), typeof(GradientLayoutRenderer))]
    namespace MyProject.UWP.Renderers
    {
        public class GradientLayoutRenderer : VisualElementRenderer<StackLayout, Panel>
        {
            private Color[] Colors { get; set; }
            private GradientColorStackMode Mode { get; set; }
            protected override void UpdateBackgroundColor()
            {
                base.UpdateBackgroundColor();
                LinearGradientBrush gradient;
                GradientStopCollection stopCollection = new GradientStopCollection();
                for (int i = 0, l = Colors.Length; i < l; i++)
                {
                    stopCollection.Add(new GradientStop
                    {
                        Color = Windows.UI.Color.FromArgb((byte)(Colors[i].A * byte.MaxValue), (byte)(Colors[i].R * byte.MaxValue), (byte)(Colors[i].G * byte.MaxValue), (byte)(Colors[i].B * byte.MaxValue)),
                        Offset = (double)i / Colors.Length
                    });
                }
                switch (Mode)
                {
                    default:
                    case GradientColorStackMode.ToRight:
                        gradient = new LinearGradientBrush
                        {
                            GradientStops = stopCollection,
                            StartPoint = new Point(0, 0.5),
                            EndPoint = new Point(1, 0.5)
                        };
                        break;
                    case GradientColorStackMode.ToLeft:
                        gradient = new LinearGradientBrush
                        {
                            GradientStops = stopCollection,
                            StartPoint = new Point(1, 0.5),
                            EndPoint = new Point(0, 0.5)
                        };
                        break;
                    case GradientColorStackMode.ToTop:
                        gradient = new LinearGradientBrush
                        {
                            GradientStops = stopCollection,
                            StartPoint = new Point(0.5, 1),
                            EndPoint = new Point(0.5, 0)
                        };
                        break;
                    case GradientColorStackMode.ToBottom:
                        gradient = new LinearGradientBrush
                        {
                            GradientStops = stopCollection,
                            StartPoint = new Point(0.5, 0),
                            EndPoint = new Point(0.5, 1)
                        };
                        break;
                    case GradientColorStackMode.ToTopLeft:
                        gradient = new LinearGradientBrush
                        {
                            GradientStops = stopCollection,
                            StartPoint = new Point(1, 1),
                            EndPoint = new Point(0, 0)
                        };
                        break;
                    case GradientColorStackMode.ToTopRight:
                        gradient = new LinearGradientBrush
                        {
                            GradientStops = stopCollection,
                            StartPoint = new Point(0, 1),
                            EndPoint = new Point(1, 0)
                        };
                        break;
                    case GradientColorStackMode.ToBottomLeft:
                        gradient = new LinearGradientBrush
                        {
                            GradientStops = stopCollection,
                            StartPoint = new Point(1, 0),
                            EndPoint = new Point(0, 1)
                        };
                        break;
                    case GradientColorStackMode.ToBottomRight:
                        gradient = new LinearGradientBrush
                        {
                            GradientStops = stopCollection,
                            StartPoint = new Point(0, 0),
                            EndPoint = new Point(1, 1)
                        };
                        break;
                }
                Background = gradient;
            }
            protected override void OnElementChanged(ElementChangedEventArgs<StackLayout> e)
            {
                base.OnElementChanged(e);
                if (e.OldElement != null || Element == null)
                    return;
                try
                {
                    if (e.NewElement is GradientLayout stack)
                    {
                        Colors = stack.Colors;
                        Mode = stack.Mode;
                        UpdateBackgroundColor();
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(@"ERROR:", ex.Message);
                }
            }
        }
    }
