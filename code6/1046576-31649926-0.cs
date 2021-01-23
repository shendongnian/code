    using namespace System::Runtime::InteropServices;
    ...
    
    virtual void LockDoc(
       CFIWarningList ^oWarnings,
       CBaseDoc ^oBaseDoc,
    // Output
       [Out] bool %rbWasAlreadyLocked
       ) override;
    
