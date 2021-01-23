        private const uint LVM_ISITEMVISIBLE = 0x1000 + 182;
        public bool ItemIsVisible(int itemIndex)
        {
            return (uint)NativeMethods.SendMessage(Handle, LVM_ISITEMVISIBLE, (IntPtr)itemIndex, (IntPtr)0) != 0;
        }
