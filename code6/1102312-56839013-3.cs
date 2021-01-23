    using System.Linq;
    using Xamarin.Forms;
    
    namespace YourProject.Effects
    {
        public class GradientEffect : RoutingEffect
        {
            public GradientEffect() : base("YourCompany.GradientEffect")
            {
            }
    
            public string Colors { get; set; }
           
            public GradientMode Mode { get; set; }
    
            public Color[] ColorList => Colors.Split(',').Select(i => Color.FromHex(i.Trim())).ToArray();
    
            public string Locations { get; set; }
    
            public float[] LocationList => Locations.Split(',').Select(float.Parse).ToArray();
    
        }
    
        public enum GradientMode
        {
            ToRight,
            ToLeft,
            ToTop,
            ToBottom,
            ToTopLeft,
            ToTopRight,
            ToBottomLeft,
            ToBottomRight,
            Null
        }
    }
