    <System.Runtime.InteropServices.
    StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential,
    CharSet:=System.Runtime.InteropServices.CharSet.Auto)>
    Public Structure MenuInfo
        Public cbSize As UInteger
        Public fMask As UInteger
        Public dwStyle As UInteger
        Public cyMax As UInteger
        Public hbrBack As IntPtr
        Public dwContextHelpID As UInteger
        Public dwMenuData As UIntPtr
    End Structure
