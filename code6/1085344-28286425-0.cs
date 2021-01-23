    // ClassLibrary1.h
    
    #pragma once
    
    using namespace System;
    
    namespace ClassLibrary1 
    {
    	public ref class Class1
    	{
        public:
            int x;
            int y;
            int width;
            int height;
        public:
            Class1() : x(42), y(666), width(24), height(13);
    	};
    }
