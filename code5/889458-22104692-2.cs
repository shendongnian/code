    #include "Cortex_SDK.h"
    #pragma once
    
    using namespace System;
    
    public ref class Marshaler
    {
    	public:
    		static FrameOfData^ MarshalFrame(IntPtr dispo)
    		{
    			// Cast the IntPtr to the unmanaged pointer
    			sFrameOfData* unmanaged = static_cast<sFrameOfData*>(dispo.ToPointer());
    			// Transform unmnaged pointer to a managed object
    			FrameOfData^ managed = gcnew FrameOfData();
    			managed->iFrame = unmanaged.iFrame;
    			// ...
    		}
    }
