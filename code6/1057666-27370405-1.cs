    #include "../Logic/Rand.cpp"
    
    using namespace System;
    
    namespace Logic {
    	namespace Managed {
    		public ref class Rand {
    			Logic::Rand * rand;
    		public:
    			Rand(UInt32 seed) { rand = new Logic::Rand(seed); }
    			!Rand() { delete rand; }
    			~Rand() { this->!Rand(); }
    			// Wrapper methods
    			UInt32 Next() { return rand->Next(); }
    		};
    	}
    }
