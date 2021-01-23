    private struct SMultivalueStructure
      {
         public ushort PropType; // Type of returned value
         public ushort Command; //Command we entered (PR_EMS_PROXY...)
         public uint dwAlignPad; // Reserved - usually 4 bytes of 0
         public uint stringArrayLength; // SWStringArray length
         public uint pStringArrayMemoryAddress; //SWStringArray pointer to string array
      }
