    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Xna.Framework;
     
    namespace MonoGameExtensions {
        public static class GameWindowExtensions {
            public static void SetPosition(this GameWindow window, Point position) {
                OpenTK.GameWindow OTKWindow = GetForm(window);
                if (OTKWindow != null) {
                    OTKWindow.X = position.X;
                    OTKWindow.Y = position.Y;
                }
            }
     
            public static OpenTK.GameWindow GetForm(this GameWindow gameWindow) {
                Type type = typeof(OpenTKGameWindow);
                System.Reflection.FieldInfo field = type.GetField("window", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                if (field != null)
                    return field.GetValue(gameWindow) as OpenTK.GameWindow;
                return null;
            }
        }
    }
