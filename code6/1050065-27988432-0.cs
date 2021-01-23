    public sealed class HuffmanFrequencyTable
    {       
        #region Properties
        /// <summary>
        /// Holds the characters and their corresponding frequencies
        /// </summary>
        public Dictionary<char, int> FrequencyTable  { get; set; } = new Dictionary<char, int>();
        #endregion
        
        #region Methods
        /// <summary>
        /// Clears the internal frequency table
        /// </summary>
        public void Clear()
        {
            FrequencyTable?.Clear();            
        }
        /// <summary>
        /// Accepts and parses a new line (string) which is then 
        /// merged with the existing dictionary or frequency table
        /// </summary>
        /// <param name="line">The line to parse</param>
        public void Accept(string line)
        {
            if (!string.IsNullOrEmpty(line))
            {
                line.GroupBy(ch => ch).
                     ToDictionary(g => g.Key, g => g.Count()).
                     ToList().
                     ForEach(x => FrequencyTable[x.Key] = x.Value);
            }
        }
        /// <summary>
        /// Performs a dump of the frequency table, ordering all characters, lowest frequency first.
        /// </summary>
        /// <returns>The frequency table in the format 'character [frequency]'</returns>
        public override string ToString()
        {            
            return FrequencyTable?.PrintFrequencies();
        }
        #endregion
    }
