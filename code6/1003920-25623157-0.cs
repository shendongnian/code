    // Initialize
    List<int> input = new List<int>();
    for (int i = 2; i < 20; i += 2) {
        input.Add(i);
    }
    // Calculate
    List<int> result = new List<int>();
    for (int i = 0; i < input.Count; i++) {
        int value = input[i];
        result.Add(value * value);
    }
    // Display
    listbox1.Items.AddRange(input);
    listbox2.Items.AddRange(result);
 
