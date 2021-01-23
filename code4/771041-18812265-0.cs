        using namespace System;
        using namespace System::Runtime::InteropServices;
    
      generic <typename T>
    public ref class SizeCache abstract sealed
    {
    private:
        static SizeCache()
        {
            Size = Marshal::SizeOf(T::typeid);
        }
    
    public:
        static int Size;
    };
    
    int main(array<System::String ^> ^args)
    {
    	double dsize = SizeCache<double>::Size;
    	int size = SizeCache<int>::Size;
        return 0;
    }
