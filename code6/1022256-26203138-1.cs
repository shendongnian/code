    class SomeClass : WhateverYouWantTheParentClassToBe, IGlobalVariables
    {
        public bool IGlobalVariables.AppIsClosing
        {
            get { return GlobalVariables.AppIsClosing; }
            set { GlobalVariables.AppIsClosing = value; }
        }
        // other code
    }
