    /// <summary>
    /// Provide some power point helper methods
    /// </summary>
    public class PowerPointHelper
    {
        /// <summary>
        /// Prepare PPTX-File
        /// </summary>
        /// <param name="pptx">Byte-Array instance, containing the PPTX file</param>
        /// <param name="textToReplace">KeyValue Pairs which will be replaced in the PPTX</param>
        /// <returns>byte array containing the</returns>
        public byte[] PreparePPTX(byte[] pptx, IDictionary<string, string> textToReplace)
        {
            if (pptx == null)
            {
                throw new ArgumentNullException("pptx");
            }
            byte[] returnValue = pptx;
            if (textToReplace != null)
            {
                // ...
                // ...
                // ...
            }
            return returnValue;
        }
    }
