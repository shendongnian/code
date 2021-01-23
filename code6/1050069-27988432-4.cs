      /// <summary>
      /// Determines whether a given Huffman node is a leaf or not.
      /// A node is considered to be a leaf when it has no childnodes
      /// </summary>
      /// <param name="node">A huffman node</param>
      /// <returns>True if no children are left, false otherwise</returns>
      public static bool IsLeaf(this HuffmanNode node)
      {
          return (null == node.Left && null == node.Right);
      }
