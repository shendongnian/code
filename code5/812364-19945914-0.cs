    public void fd() {
      string input = Console.ReadLine();
      int index = 0;
      while (index < input.Length) {
        if (!Char.IsLetterOrDigit(input, index) && ((index == 0 || !Char.IsLetterOrDigit(input, index - 1)) || (index == input.Length - 1 || !Char.IsLetterOrDigit(input, index + 1)))) {
          input = input.Remove(index, 1);
        } else {
          index++;
        }
      }
      Console.WriteLine(input);
    }
