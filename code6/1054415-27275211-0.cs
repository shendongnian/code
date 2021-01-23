    public void positionCallback(uint devNo,uint count,uint index,System.IntPtr pos,ref System.IntPtr mrk)
    // copy the array of pointers
    IntPtr[] arrays = new IntPtr[3];
    Marshal.Copy(pos, arrays, 0, 3);
    // Copy the unmanaged array to managed memory for Axis 2
    Marshal.Copy(arrays[0],managedArrayAxis1,0,(int)count);
    // Copy the unmanaged array to managed memory for Axis 2
    Marshal.Copy(arrays[1], managedArrayAxis2, 0, (int)count);
