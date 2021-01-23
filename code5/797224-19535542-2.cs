    namespace MathNet.Numerics
    {
        public static class DenseVectorExtensions
        {
            public static DenseVector AddAlls(this DenseVector vdA, DenseVector vdB)
            {
               return DenseVector.OfEnumerable(
                         vdA.SelectMany(x => vdB, (y, z) => { return y + z; })
                      );
            }
        }
    }
