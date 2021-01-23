    double num1, num2;
    if (double.TryParse(inputOne.Text, out num1) && double.TryParse(inputTwo.Text, out num2))
    { ... values are valid, so do things}
    else
    { ... at least one value is not valid... warn user }
