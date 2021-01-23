    public Color[] convertToColorArray() {
        for (int i = 0; i < rows; i++) {
            //This gives us an array of 3 strings each representing a number in text form.
            var splitString = stringArray[i].Split(','); 
            //converts the array of 3 strings in to an array of 3 ints.
            var splitInts = splitString.Select(item => int.Parse(item)).ToArray(); 
            //takes each element of the array of 3 and passes it in to the correct slot
            colorArray[i] = System.Drawing.Color.FromArgb(splitInts[0], splitInts[1], splitInts[2]); 
        }
        return colorArray;
    }
