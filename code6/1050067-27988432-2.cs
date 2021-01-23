    public sealed class HuffmanNode
    {
        #region Properties
        /// <summary>
        /// Holds the left node, if applicable, otherwise null
        /// </summary>
        public HuffmanNode Left { get; set; } = null;
        
        /// <summary>
        /// Holds the right node, if applicable, otherwise null
        /// </summary>
        public HuffmanNode Right { get; set; } = null;
        /// <summary>
        /// Holds the Character (or null) for this particular node
        /// </summary>
        public char? Character { get; set; } = null;
        /// <summary>
        /// Holds the frequency for this particular node, defaulted to 0
        /// </summary>
        public int Frequency { get; set; } = default(int);
        
        #endregion
        #region Methods
        /// <summary>
        /// Traverses all nodes recursively returning the binary 
        /// path for the corresponding character that has been found.
        /// </summary>
        /// <param name="character">The character to find</param>
        /// <param name="data">The datapath (containing '1's and '0's)</param>
        /// <returns>The complete binary path for a character within a node</returns>
        public List<bool> Traverse(char? character, List<bool> data)
        {
            //Check the leafs for existing characters
            if (null == Left && null == Right)
            {
                //We're at an endpoint of our 'tree', so return it's data or nothing when the symbol
                //characters do not match
                return (bool)character?.Equals(Character) ? data : null;
            }
            else
            {
                List<bool> left = null;
                List<bool> right = null;
                //TODO: If possible refactor with proper C# 6.0 features
                if (null != Left)
                {
                    List<bool> leftPath = new List<bool>(data);                    
                    leftPath.Add(false); //Add a '0'
                    left = Left.Traverse(character, leftPath); //Recursive traversal for child nodes within this left node.
                }
                if (null != Right)
                {
                    List<bool> rightPath = new List<bool>(data);                    
                    rightPath.Add(true); //Add a '1'
                    right = Right.Traverse(character, rightPath); //Recursive traversal for childnodes within this right node
                }
                return (null != left) ? left : right;
            }
        }        
        #endregion
    }
