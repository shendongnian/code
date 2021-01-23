    private static System.Array ToSystemMatrix<T>(ILInArray<T> A) {
        using (ILScope.Enter(A)) {
            // some error checking (to be improved...)
            if (object.Equals(A, null)) throw new ArgumentException("A may not be null");
            if (!A.IsMatrix) throw new ArgumentException("Matrix expected");
            // create return array
            System.Array ret = Array.CreateInstance(typeof(T), A.S.ToIntArray().Reverse().ToArray());
            // fetch underlying system array
            T[] workArr = A.GetArrayForRead();
            // copy memory block 
            Buffer.BlockCopy(workArr, 0, ret, 0, Marshal.Sizeof(T) * A.S.NumberOfElements);
            return ret;
        }
    }
