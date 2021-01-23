    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SFML;
    using SFML.Graphics;
    using SFML.Window;
    namespace Source
    {
    class ColorWheel : IGameObject
    {
        Image image = new Image(240, 220);
        HSLColor hslColor = new HSLColor();
        System.Drawing.Color systemColor = new System.Drawing.Color();
        Color pixelcolor = new Color();
        public Sprite sprite = new Sprite();
        public ColorWheel()
        {
            pixelcolor = Color.Red;
            hslColor.SetRGB(pixelcolor.R, pixelcolor.G, pixelcolor.B);
            for (int y = 0; y < 220; y++)
            {
                //pixelcolor = Color.Red;
                //hslColor.SetRGB(pixelcolor.R, pixelcolor.G, pixelcolor.B);
                hslColor.Hue = 0;
                    for (int x = 0; x < 240; x++)
                    {
                        systemColor = hslColor;
                        pixelcolor.R = systemColor.R;
                        pixelcolor.G = systemColor.G;
                        pixelcolor.B = systemColor.B;
                        image.SetPixel((uint)x, (uint)y, pixelcolor);
                        hslColor.Hue += 1;
                    }
                    hslColor.Saturation -= (y * 0.01);
            }
            Texture texture = new Texture(image);
            sprite.Texture = texture;
        }
        
        public void Update(double dt)
        {
        }
        
        public void Render(RenderWindow rWindow)
        {
            rWindow.Draw(sprite);
        }
        
    }
    }
