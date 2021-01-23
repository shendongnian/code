    public partial class MainWindow : Window
    {
	private bool toggle = true;
    }
    private void fireUp(rwKey hotKey)
        {
            byte[] byt ={0xC7,0x83,0x1A,0x05,0x00,0x00,0x00,0x00,0x00,0x00,0x48,0x8B,0x74,0x24,
            0x40,0x48,0x8B,0x6C,0x24,0x48,0x48,0x8B,0x5C,0x24,0x50,0x48,0x83,0xC4,0x58,0xC3};
            for (int i = 6; i < 10; ++i) { byt[i] = (byte)(atkSpd & 0xFF); atkSpd = atkSpd >> 8; }
            bool kd = (toggle = !toggle);
            if (kd)
            {
                Write(vMemory + 8, byt, 30);
                Write(vMemory, BitConverter.GetBytes((vMemory + 8)), 8);
                Write(atkBase, new byte[] { 0xFF, 0x24, 0x25 }, 3);
                Write(atkBase + 3, BitConverter.GetBytes((vMemory)), 4);
            }
            else
            {
                Write(atkBase, new byte[] { 0x66, 0x89, 0xB3, 0x1A, 0x05, 0x00, 0x00 }, 7);
            }
        }
 
