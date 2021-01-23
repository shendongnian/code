    var lines = new List<string>(currentText.Split('\n'));
    var newlines = new List<string>();
    foreach (var line in lines) {
        if (line != "Value: 10") {
            newLines.Add(line); // This line is correct, no marking needed
        } else {
            newlines.Add("THIS IS WRONG: " + line); // Mark as incorrect; use whatever you need here
        }
    }
    // Next, return newlines to the user showing them which lines are bad so they can edit the PDF
