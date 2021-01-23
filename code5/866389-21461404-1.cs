    public enum class AVCodecID : long
    {
        mp4 = 1,
        mpeg2 = 2,
        ...
   }
    public ref class AVCodecDescriptor
    {
        AVCodecID id,
        ...
        System::String name
        ...
    }
