    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.GamerServices;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework.Media;
    
    namespace TileGame
    {
        class KeyboardEntering
        {
            private KeyboardState ksCurr;
            private KeyboardState ksPrev;
    
            public KeyboardEntering()
            {
    
            }
    
            public string Update(string enterString)
            {
                string exitString = enterString;
                ksCurr = Keyboard.GetState();
                if (!IsPressed(Keys.LeftShift) && !IsPressed(Keys.RightShift))
                {
                    if (OnRelease(Keys.A)) exitString += "a";
                    if (OnRelease(Keys.B)) exitString += "b";
                    if (OnRelease(Keys.C)) exitString += "c";
                    if (OnRelease(Keys.D)) exitString += "d";
                    if (OnRelease(Keys.E)) exitString += "e";
                    if (OnRelease(Keys.F)) exitString += "f";
                    if (OnRelease(Keys.G)) exitString += "g";
                    if (OnRelease(Keys.H)) exitString += "h";
                    if (OnRelease(Keys.I)) exitString += "i";
                    if (OnRelease(Keys.J)) exitString += "j";
                    if (OnRelease(Keys.K)) exitString += "k";
                    if (OnRelease(Keys.L)) exitString += "l";
                    if (OnRelease(Keys.M)) exitString += "m";
                    if (OnRelease(Keys.N)) exitString += "n";
                    if (OnRelease(Keys.O)) exitString += "o";
                    if (OnRelease(Keys.P)) exitString += "p";
                    if (OnRelease(Keys.Q)) exitString += "q";
                    if (OnRelease(Keys.R)) exitString += "r";
                    if (OnRelease(Keys.S)) exitString += "s";
                    if (OnRelease(Keys.T)) exitString += "t";
                    if (OnRelease(Keys.U)) exitString += "u";
                    if (OnRelease(Keys.V)) exitString += "v";
                    if (OnRelease(Keys.W)) exitString += "w";
                    if (OnRelease(Keys.X)) exitString += "x";
                    if (OnRelease(Keys.Y)) exitString += "y";
                    if (OnRelease(Keys.Z)) exitString += "z";
                }
                
                if (IsPressed(Keys.LeftShift) || IsPressed(Keys.RightShift))
                {
                    if (OnRelease(Keys.A)) exitString += "A";
                    if (OnRelease(Keys.B)) exitString += "B";
                    if (OnRelease(Keys.C)) exitString += "C";
                    if (OnRelease(Keys.D)) exitString += "D";
                    if (OnRelease(Keys.E)) exitString += "E";
                    if (OnRelease(Keys.F)) exitString += "F";
                    if (OnRelease(Keys.G)) exitString += "G";
                    if (OnRelease(Keys.H)) exitString += "H";
                    if (OnRelease(Keys.I)) exitString += "I";
                    if (OnRelease(Keys.J)) exitString += "J";
                    if (OnRelease(Keys.K)) exitString += "K";
                    if (OnRelease(Keys.L)) exitString += "L";
                    if (OnRelease(Keys.M)) exitString += "M";
                    if (OnRelease(Keys.N)) exitString += "N";
                    if (OnRelease(Keys.O)) exitString += "O";
                    if (OnRelease(Keys.P)) exitString += "P";
                    if (OnRelease(Keys.Q)) exitString += "Q";
                    if (OnRelease(Keys.R)) exitString += "R";
                    if (OnRelease(Keys.S)) exitString += "S";
                    if (OnRelease(Keys.T)) exitString += "T";
                    if (OnRelease(Keys.U)) exitString += "U";
                    if (OnRelease(Keys.V)) exitString += "V";
                    if (OnRelease(Keys.W)) exitString += "W";
                    if (OnRelease(Keys.X)) exitString += "X";
                    if (OnRelease(Keys.Y)) exitString += "Y";
                    if (OnRelease(Keys.Z)) exitString += "Z";
                }
                if (OnRelease(Keys.Space)) exitString += " ";
                
                if (OnRelease(Keys.Back))
                {
                    if(exitString.Length != 0) exitString = exitString.Substring(0, exitString.Length - 1);
                }
    
                ksPrev = ksCurr;
                return exitString;
            }
    
            public bool OnRelease(Keys key)
            {
                if (ksCurr == null) return false;
                if (ksPrev == null) return false;
                return ksCurr.IsKeyUp(key) && ksPrev.IsKeyDown(key);
            }
            public bool IsPressed(Keys key)
            {
                if (ksCurr == null) return false;
                return ksCurr.IsKeyDown(key);
            }
        }
    }
