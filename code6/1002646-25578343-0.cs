    namespace BO2
    {
        internal class Typewriter
        {
            uint AllClientHUD = 1023;//Set A Certain Element To All Clients
            PS3API PS3 = new PS3API();
 
            public static byte[] ToHexFloat(float Axis)
            {
                byte[] bytes = BitConverter.GetBytes(Axis);
                Array.Reverse(bytes);
                return bytes;
            }
 
            public static void SetGlow(int elemIndex, int r1, int g1, int b1, int a1)
            {
                uint elem = OffsetsHUD.G_HudElems + ((Convert.ToUInt32(elemIndex)) * 0x88);
                PS3.SetMemory(elem + HElems.glowColor, RGBA(r1, g1, b1, a1));
                System.Threading.Thread.Sleep(20);
            }
              
            ...
 
        }
    }
