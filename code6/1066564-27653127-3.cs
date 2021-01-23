    internal class AinAppA : ParentA
    {
        internal AinAppA()
        {
            this.AppAInternal = 1; // can access parents protected members
            // this.ReallyInternal = 2; // but pure internal members are not visible
        }
    }
