    [DllImport("C:\\...\\HashCplusDll.dll", CallingConvention= CallingConvention.Cdecl)]
            public static extern int insert_In_Table(ref Wavfile sample);
            public static int recordNumber_old = 0;
            //StructLayout(LayoutKind.Sequential)]
            public struct Wavfile
            {
    
                public int length;
                public IntPtr value;
            }
    
            public void button1_Click(object sender, EventArgs e)
            {
                // open file dialog 
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "All files (*.*)|*.*";
                if (open.ShowDialog() == DialogResult.OK)
                {
    
                    string location = open.FileName;
                    byte[] array = System.IO.File.ReadAllBytes(location);
                    textBox1.Text = location;
    
                    Wavfile pass = new Wavfile();
    
                    pass.length = array.Length;
                    pass.value = Marshal.AllocHGlobal(array.Length);
                    Marshal.Copy(array, 0, pass.value, array.Length);
                    // Call unmanaged code
                    int numberOfRow = insert_In_Table(ref pass);
    }
