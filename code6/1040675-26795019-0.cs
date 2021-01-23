    int Answer; // declares the Answer variable outside button event
    int Guesses = 0; // declare this outside button event, and initialize it to 0.
                     // initialization will happen when the Form object is created.
    ...
    private void btnGuess_Click(object sender, EventArgs e)
    {
        int UserGuess;
        // DO NOT reset the counter here. This line is the culprit that
        // resets the counter every time you click the button
        //int Guesses = 0;     // start counter
        ...
    } 
    ...
