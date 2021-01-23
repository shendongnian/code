using System.Runtime.InteropServices
        private unsafe byte[] FloatsToBytes(float[] floats) {
            fixed (void* pFloats = floats) {
                byte* pBytes = (byte*)pFloats;
                byte[] bytes = new byte[sizeof(float) * floats.Length];
                Marshal.Copy((IntPtr)pBytes, bytes, 0, floats.Length * sizeof(byte));
                return bytes;
            }
        }
        private unsafe float[] BytesToFloats(byte[] bytes) {
            fixed (void* pBytes = bytes) {
                float* pFloats = (float*)pBytes;
                float[] floats = new float[bytes.Length / sizeof(float)];
                Marshal.Copy((IntPtr)pFloats, floats, 0, bytes.length / sizeof(float));
                return floats;
            }
        }
