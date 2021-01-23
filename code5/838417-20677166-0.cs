    namespace Application.Core.Common
    {
    using System.Collections.Generic;
    public class EmpMasterIDocBufferComparer : IEqualityComparer<EmpMasterIDocBuffer>
    {
        /// <summary>
        /// Equality check
        /// </summary>
        /// <param name="x">EmpMasterIDocBuffer x</param>
        /// <param name="y">EmpMasterIDocBuffer y</param>
        /// <returns>Returns true false</returns>
        public bool Equals(EmpMasterIDocBuffer x, EmpMasterIDocBuffer y)
        {
            if (x.Index== y.ANUPFROM
                && x.AutoId == y.ANUPTOM
                && x.Buffer== y.Buffer, System.StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// To get hash code
        /// </summary>
        /// <param name="obj">ANSU object</param>
        /// <returns>UTYP id</returns>
        public int GetHashCode(EmpMasterIDocBuffer obj)
        {
            return obj == null ? 0 : obj.Index;
        }
    }
