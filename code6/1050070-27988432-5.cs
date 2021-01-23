     string input = tbInput.Text;
     Tree.BuildTree(input); //Build the huffman tree
     BitArray encoded = Tree.Encode(input); //Encode the tree
     //First show the generated binary output
     tbBinaryOutput.Text = string.Join(string.Empty, encoded.Cast<bool>().Select(bit => bit ? "1" : "0"));
      //Next, convert the binary output to the new characterized output string.       
      byte[] bytes = new byte[(encoded.Length / 8) + 1];
      encoded.CopyTo(bytes, 0);
      tbOutput.Text = Encoding.Default.GetString(bytes); //Write the compressed output to the textbox.
