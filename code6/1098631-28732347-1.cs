    List<int> ListElementsDivisibleBy3Recursive(List<int> input) {
        if (input.Count > 0) {
            int last = input.Last();
            input.RemoveAt(input.Count - 1);
            input = ListElementsDivisibleBy3Recursive(input);
            if (last % 3 == 0)
                input.Add(last);
        }
        return input;
    }
